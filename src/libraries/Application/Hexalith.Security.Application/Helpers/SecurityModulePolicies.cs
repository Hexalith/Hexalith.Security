// <copyright file="SecurityModulePolicies.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application.Helpers;

using System.Collections.Generic;

using Hexalith.Application;
using Hexalith.Security.Application;

using Microsoft.AspNetCore.Authorization;

/// <summary>
/// Provides authorization policies for the document module.
/// </summary>
public static class SecurityModulePolicies
{
    /// <summary>
    /// Gets the authorization policies for the document module.
    /// </summary>
    public static IDictionary<string, AuthorizationPolicy> AuthorizationPolicies =>
    new Dictionary<string, AuthorizationPolicy>
    {
        {
            SecurityPolicies.Owners, new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(ApplicationRoles.GlobalAdministrator, SecurityRoles.Owner)
                .Build()
        },
        {
            SecurityPolicies.Contributors, new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(ApplicationRoles.GlobalAdministrator, SecurityRoles.Owner, SecurityRoles.Contributor)
                .Build()
        },
        {
            SecurityPolicies.Readers, new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(ApplicationRoles.GlobalAdministrator, SecurityRoles.Owner, SecurityRoles.Contributor, SecurityRoles.Reader)
                .Build()
        },
    };

    /// <summary>
    /// Adds the document module policies to the specified authorization options.
    /// </summary>
    /// <param name="options">The authorization options to add the policies to.</param>
    /// <returns>The updated authorization options.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the options parameter is null.</exception>
    public static AuthorizationOptions AddSecurityAuthorizationPolicies(this AuthorizationOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        foreach (KeyValuePair<string, AuthorizationPolicy> policy in AuthorizationPolicies)
        {
            options.AddPolicy(policy.Key, policy.Value);
        }

        return options;
    }
}