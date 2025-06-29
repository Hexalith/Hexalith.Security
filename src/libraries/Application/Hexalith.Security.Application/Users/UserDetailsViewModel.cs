// <copyright file="UserDetailsViewModel.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application.Users;

using Hexalith.Domains.ValueObjects;

/// <summary>
/// Represents the details of a user in the application.
/// </summary>
public class UserDetailsViewModel : IIdDescription
{
    /// <inheritdoc/>
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc/>
    string IIdDescription.Description => Name;
}