// <copyright file="ClientPrincipal.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.WebServer.Models;

using System.Runtime.Serialization;

/// <summary>
/// Represents the client principal information.
/// </summary>
/// <param name="IdentityProvider">The identity provider.</param>
/// <param name="Claims">The claims associated with the client principal.</param>
/// <param name="NameClaimType">The name claim type.</param>
/// <param name="RoleClaimType">The role claim type.</param>
[DataContract]
public record ClientPrincipal(
    [property: DataMember(Name = "auth_typ")] string IdentityProvider,
    [property: DataMember(Name = "claims")] IEnumerable<ClientPrincipalClaim> Claims,
    [property: DataMember(Name = "name_typ")] string NameClaimType,
    [property: DataMember(Name = "role_typ")] string RoleClaimType);