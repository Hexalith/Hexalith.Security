namespace Hexalith.Security.Servers.Authentications;

using Microsoft.AspNetCore.Authentication;

/// <summary>
/// Options for Azure Container App Authentication.
/// </summary>
public class AzureContainerAppAuthenticationOptions : AuthenticationSchemeOptions
{
    /// <summary>
    /// Gets the authentication type.
    /// </summary>
    public static string AuthenticationType => DefaultScheme;

    /// <summary>
    /// Gets the default scheme for Azure Container App Authentication.
    /// </summary>
    public static string DefaultScheme => "AzureContainerAppAuthentication";

    /// <summary>
    /// Gets the scheme.
    /// </summary>
    public static string Scheme => DefaultScheme;
}