// <copyright file="SecurityRoles.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application;

/// <summary>
/// Defines the roles for document security within the application.
/// </summary>
public static class SecurityRoles
{
    /// <summary>
    /// Role for users who can contribute to documents.
    /// </summary>
    public const string Contributor = nameof(Security) + nameof(Contributor);

    /// <summary>
    /// Role for users who own documents.
    /// </summary>
    public const string Owner = nameof(Security) + nameof(Owner);

    /// <summary>
    /// Role for users who can read documents.
    /// </summary>
    public const string Reader = nameof(Security) + nameof(Reader);
}