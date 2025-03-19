namespace Hexalith.Security.Servers.Authentications;

using Microsoft.AspNetCore.Authentication;

/// <summary>
/// Options for Azure Container App Authentication.
/// </summary>
public class AzureContainerAppGoogleAuthenticationOptions : RemoteAuthenticationOptions, IAzureContainerAppAuthenticationOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AzureContainerAppGoogleAuthenticationOptions"/> class.
    /// </summary>
    public AzureContainerAppGoogleAuthenticationOptions() => CallbackPath = "/.auth/login/google";

    /// <summary>
    /// Gets the default scheme for Azure Container App Authentication.
    /// </summary>
    public static string DefaultScheme => "EasyGoogle";

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