﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NeerCore.Exceptions;
using NetHub.Application.Tools;
using NetHub.Core.Constants;
using NetHub.Core.Exceptions;
using NetHub.Data.SqlServer.Entities;
using NetHub.Data.SqlServer.Entities.Articles;
using NetHub.Data.SqlServer.Entities.Identity;
using NetHub.Data.SqlServer.Enums;

namespace NetHub.Application.Features.Public.Articles.Localizations.Update;

internal sealed class UpdateArticleLocalizationHandler : AuthorizedHandler<UpdateArticleLocalizationRequest>
{
    private readonly DbSet<ArticleLocalization> _localizations;

    public UpdateArticleLocalizationHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _localizations = Database.Set<ArticleLocalization>();
    }

    public override async Task<Unit> Handle(UpdateArticleLocalizationRequest request, CancellationToken ct)
    {
        var userId = UserProvider.UserId;
        var localization = await _localizations
            .Include(al => al.Contributors)
            .SingleOrDefaultAsync(al =>
                al.ArticleId == request.ArticleId && al.LanguageCode == request.OldLanguageCode, ct);
        if (localization is null)
            throw new NotFoundException("No such article localization");

        if (localization.Contributors.All(ac => ac.Id != userId))
            throw new PermissionsException();

        if (localization.Status == ContentStatus.Published)
            throw new ApiException("You can not edit published article");

        SetNewFields(request, localization);

        if (request.Html is not null)
        {
            localization.Html = request.Html;
            await HtmlTools.CheckLinks(Database, request.ArticleId, request.Html);
        }

        if (request.Contributors is not null)
            await SetContributors(localization, request.Contributors, ct);

        if (request.NewLanguageCode is not null)
            await SetNewLanguageAsync(request, localization, ct);

        localization.Updated = DateTime.UtcNow;
        localization.LastContributorId = userId;

        await Database.SaveChangesAsync(ct);

        return Unit.Value;
    }

    private async Task SetNewLanguageAsync(UpdateArticleLocalizationRequest request, ArticleLocalization localization, CancellationToken ct = default)
    {
        if (_localizations.Count(l =>
                l.ArticleId == request.ArticleId
                && l.LanguageCode == request.NewLanguageCode) == 1)
            throw new ValidationFailedException("NewLanguageCode",
                "Article Localization with such language already exists");

        if (request.OldLanguageCode == ProjectConstants.UA)
            throw new ValidationFailedException("NewLanguageCode", "There are must be one localization in ukrainian");

        if (await Database.Set<Language>().FirstOrDefaultAsync(l => l.Code == request.NewLanguageCode, ct) is null)
            throw new ValidationFailedException("LanguageCode", "No such language registered");

        localization.LanguageCode = request.NewLanguageCode!;
    }

    private async Task SetContributors(
        ArticleLocalization localization,
        IReadOnlyCollection<ArticleContributorModel> requestContributors,
        CancellationToken ct = default)
    {
        if (requestContributors.FirstOrDefault(a => a.Role == ArticleContributorRole.Author) is not null)
            throw new ApiException("You can not set authors");

        var newContributors =
            localization.Contributors
                .Where(c => c.Role == ArticleContributorRole.Author)
                .ToList();

        foreach (var contributor in requestContributors)
        {
            var count = requestContributors.Count(a => a.UserId == contributor.UserId && a.Role == contributor.Role);
            if (count > 1)
                throw new ApiException("One user can not contribute the same role several times");

            var dbContributor = await Database.Set<AppUser>()
                .FirstOrDefaultAsync(p => p.Id == contributor.UserId, ct);
            if (dbContributor is null)
                throw new ApiException($"No user with id: {contributor.UserId}");

            newContributors.Add(contributor.Adapt<ArticleContributor>());
        }

        localization.Contributors = newContributors;
        await Database.SaveChangesAsync(ct);
    }

    private static void SetNewFields(UpdateArticleLocalizationRequest request, ArticleLocalization localization)
    {
        if (request.Title is not null)
            localization.Title = request.Title;

        if (request.Description is not null)
            localization.Description = request.Description;
    }
}