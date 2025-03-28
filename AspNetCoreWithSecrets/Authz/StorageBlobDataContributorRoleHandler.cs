﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithSecrets.Authz;

public class StorageBlobDataContributorRoleHandler : AuthorizationHandler<StorageBlobDataContributorRoleRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        StorageBlobDataContributorRoleRequirement requirement
    )
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(requirement);

        //  "6705345e-c37e-4f7a-b2d9-e2f43e029524" // StorageContributorsAzureADfiles

        var spIdUserGroup = context.User.Claims.FirstOrDefault(t => t.Type == "groups" &&
        t.Value == "6705345e-c37e-4f7a-b2d9-e2f43e029524");

        if (spIdUserGroup != null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}