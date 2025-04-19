// <copyright file="SecuritySettings.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application.Configurations;

using System.Runtime.Serialization;

using Hexalith.Extensions.Configuration;

/// <summary>
/// Security settings.
/// </summary>
/// <param name="Disabled"> Indicates if the security is disabled.</param>
[DataContract]
public record SecuritySettings([property: DataMember(Order = 6)] bool Disabled) : ISettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecuritySettings"/> class.
    /// Needed for serialization.
    /// </summary>
    public SecuritySettings()
        : this(false)
    {
    }

    /// <summary>
    /// The name of the configuration.
    /// </summary>
    /// <returns>Settings section name.</returns>
    public static string ConfigurationName() => nameof(Hexalith) + ":" + nameof(Security);
}