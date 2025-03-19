namespace Hexalith.Security.Servers.Authentications;

using Microsoft.AspNetCore.Authentication;

/// <summary>
/// Options for Azure Container App Authentication.
/// </summary>
public class AzureContainerAppXAuthenticationOptions : RemoteAuthenticationOptions, IAzureContainerAppAuthenticationOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AzureContainerAppXAuthenticationOptions"/> class.
    /// </summary>
    public AzureContainerAppXAuthenticationOptions() => CallbackPath = "/.auth/login/x";

    /// <summary>
    /// Gets the default scheme for Azure Container App Authentication.
    /// </summary>
    public static string DefaultScheme => "EasyX";

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