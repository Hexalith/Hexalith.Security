namespace Hexalith.Security.Servers.Authentications;

/// <summary>
/// Options interface for Azure Container App Authentication identity provider.
/// </summary>
public interface IAzureContainerAppAuthenticationOptions
{
    /// <summary>
    /// Gets the authentication type.
    /// </summary>
    string AuthenticationType { get; }

    /// <summary>
    /// Gets the default scheme for Azure Container App Authentication.
    /// </summary>
    string DefaultScheme { get; }

    /// <summary>
    /// Gets the scheme.
    /// </summary>
    string Scheme { get; }
}