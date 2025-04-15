// <copyright file="ApplicationRole.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application.Roles;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Represents an application-specific role that extends the functionality of <see cref="IdentityRole"/>.
/// </summary>
public class ApplicationRole : IdentityRole
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
    /// </summary>
    public ApplicationRole()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRole"/> class with a specified role name.
    /// </summary>
    /// <param name="roleName">The name of the role.</param>
    public ApplicationRole(string roleName)
        : base(roleName)
    {
    }
}