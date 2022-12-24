﻿using Mapster;
using Microsoft.EntityFrameworkCore;
using NetHub.Application.Tools;
using NetHub.Data.SqlServer.Entities.ArticleEntities;

namespace NetHub.Application.Features.Public.Articles.User;

internal sealed class GetUserArticlesHandler : AuthorizedHandler<GetUserArticlesRequest, ArticleModel[]>
{
    public GetUserArticlesHandler(IServiceProvider serviceProvider) : base(serviceProvider) { }


    public override async Task<ArticleModel[]> Handle(GetUserArticlesRequest request, CancellationToken ct)
    {
        var userId = UserProvider.GetUserId();

        var articles = await Database.Set<Article>()
            .Include(a => a.Localizations)
            .Where(a => a.AuthorId == userId)
            .Skip((request.Page - 1) * request.PerPage)
            .Take(request.PerPage)
            .ProjectToType<ArticleModel>()
            .ToArrayAsync(ct);

        return articles;
    }
}