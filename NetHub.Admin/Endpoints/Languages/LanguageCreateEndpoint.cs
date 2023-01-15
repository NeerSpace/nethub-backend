using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeerCore.Exceptions;
using NetHub.Admin.Abstractions;
using NetHub.Admin.Infrastructure.Models.Languages;
using NetHub.Data.SqlServer.Context;
using NetHub.Data.SqlServer.Entities;

namespace NetHub.Admin.Endpoints.Languages;

[ApiVersion(Versions.V1)]
[Tags(TagNames.Languages)]
// [Authorize(Policy = Policies.HasManageUsersPermission)]
[AllowAnonymous]
public sealed class LanguageCreateEndpoint : Endpoint<LanguageModel, LanguageModel>
{
    private readonly ISqlServerDatabase _database;
    public LanguageCreateEndpoint(ISqlServerDatabase database) => _database = database;


    [HttpPost("languages")]
    public override async Task<LanguageModel> HandleAsync([FromBody] LanguageModel request, CancellationToken ct = default)
    {
        if (await _database.Set<Language>().CountAsync(l => l.Code == request.Code, ct) > 0)
            throw new ValidationFailedException("Language with given code already exists.");

        var language = request.Adapt<Language>();
        _database.Set<Language>().Add(language);
        await _database.SaveChangesAsync(ct);

        return language.Adapt<LanguageModel>();
    }
}