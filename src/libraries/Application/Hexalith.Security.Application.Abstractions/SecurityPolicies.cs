// <copyright file="SecurityPolicies.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application;

/// <summary>
/// Defines the policies for security module within the application.
/// </summary>
public static class SecurityPolicies
{
    /// <summary>
    /// Policy for users who can contribute to documents.
    /// </summary>
    public const string Contributors = nameof(Security) + nameof(Contributors);

    /// <summary>
    /// Policy for users who own documents.
    /// </summary>
    public const string Owners = nameof(Security) + nameof(Owners);

    /// <summary>
    /// Policy for users who can read documents.
    /// </summary>
    public const string Readers = nameof(Security) + nameof(Readers);
}