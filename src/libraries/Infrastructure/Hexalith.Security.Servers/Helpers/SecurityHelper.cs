// <copyright file="SecurityHelper.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Servers.Helpers;

using Hexalith.Security.Application;
using Hexalith.Security.Application.Users;
using Hexalith.Security.Servers.Roles;
using Hexalith.Security.Servers.Users;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides helper methods for adding security UI components to the service collection.
/// </summary>
public static class SecurityHelper
{
    /// <summary>
    /// Adds the security UI components to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the components to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddSecurityUIComponents(this IServiceCollection services)
    {
        _ = services.AddScoped<IUserService, UserService>();
        _ = services.AddScoped<IRoleService, RoleService>();
        return services;
    }
}