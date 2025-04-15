// <copyright file="UserSummaryViewModel.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application.Users;

/// <summary>
/// Represents a summary view model for a user.
/// </summary>
/// <param name="Id">The unique identifier of the user.</param>
/// <param name="Name">The name of the user.</param>
/// <param name="Email">The email address of the user.</param>
/// <param name="Disabled">Indicates whether the user is disabled.</param>
/// <param name="GlobalAdministrator">Indicates whether the user is a global administrator.</param>
public record UserSummaryViewModel(
    string Id,
    string? Name,
    string? Email,
    bool Disabled,
    bool GlobalAdministrator);