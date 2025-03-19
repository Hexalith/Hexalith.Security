namespace Hexalith.Security.Servers.Authentications;

using Microsoft.AspNetCore.Authentication;

/// <summary>
/// Options for Azure Container App Authentication.
/// </summary>
public class AzureContainerAppFacebookAuthenticationOptions : RemoteAuthenticationOptions, IAzureContainerAppAuthenticationOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AzureContainerAppFacebookAuthenticationOptions"/> class.
    /// </summary>
    public AzureContainerAppFacebookAuthenticationOptions() => CallbackPath = "/.auth/login/facebook";

    /// <summary>
    /// Gets the default scheme for Azure Container App Authentication.
    /// </summary>
    public static string DefaultScheme => "EasyFacebook";

    /// <summary>
    /// Gets the authentication type.
    /// </summary>
    public string AuthenticationType => DefaultScheme;

    /// <summary>
    /// Gets the scheme.
    /// </summary>
    public string Scheme => DefaultScheme;

    /// <summary>
    /// Gets the default scheme for Azure Container App Authentication.
    /// </summary>
    string IAzureContainerAppAuthenticationOptions.DefaultScheme => DefaultScheme;
}