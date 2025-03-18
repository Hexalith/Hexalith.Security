namespace Hexalith.Security.Application.Configurations;

using System.Runtime.Serialization;

using Hexalith.Extensions.Configuration;

/// <summary>
/// Security settings.
/// </summary>
[DataContract]
public record SecuritySettings(
    [property: DataMember(Order = 1)] bool EasyAuthMicrosoft,
    [property: DataMember(Order = 1)] bool EasyAuthGithub,
    [property: DataMember(Order = 1)] bool EasyAuthGoogle,
    [property: DataMember(Order = 1)] bool EasyAuthX,
    [property: DataMember(Order = 1)] bool Disabled) : ISettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecuritySettings"/> class.
    /// </summary>
    public SecuritySettings()
        : this(true, false, false, false, false)
    {
    }

    /// <summary>
    /// The name of the configuration.
    /// </summary>
    /// <returns>Settings section name.</returns>
    public static string ConfigurationName() => nameof(Hexalith) + ":" + nameof(Security);
}