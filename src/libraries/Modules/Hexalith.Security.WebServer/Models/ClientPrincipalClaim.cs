// <copyright file="ClientPrincipalClaim.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.WebServer.Models;

using System.Runtime.Serialization;

/// <summary>
/// Represents a claim associated with the client principal.
/// </summary>
/// <param name="Type">The type of the claim.</param>
/// <param name="Value">The value of the claim.</param>
[DataContract]
public record ClientPrincipalClaim(
    [property: DataMember(Name = "typ")] string Type,
    [property: DataMember(Name = "val")] string Value)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientPrincipalClaim"/> class.
    /// </summary>
    public ClientPrincipalClaim()
        : this(string.Empty, string.Empty)
    {
    }
}