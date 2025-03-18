namespace Hexalith.Security.Servers.Authentications;

using Microsoft.AspNetCore.Authentication;

/// <summary>
/// Options for Azure Container App Authentication.
/// </summary>
public class AzureContainerAppAuthenticationOptions : AuthenticationSchemeOptions
{
    /// <summary>
    /// The default scheme for Azure Container App Authentication.
    /// </summary>
    public const string DefaultScheme = "AzureContainerAppAuthentication";

    /// <summary>
    /// Gets or sets the authentication type.
    /// </summary>
    public string AuthenticationType = DefaultScheme;

    /// <summary>
    /// Gets the scheme.
    /// </summary>
    public static string Scheme => DefaultScheme;
}