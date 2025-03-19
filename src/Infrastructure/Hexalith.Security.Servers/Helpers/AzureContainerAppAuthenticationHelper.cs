namespace Hexalith.Security.Servers.Helpers;

using Hexalith.Security.Servers.Authentications;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for adding Azure Container App authentication.
/// </summary>
public static class AzureContainerAppAuthenticationHelper
{
    /// <summary>
    /// Adds Azure Container App authentication to the specified <see cref="AuthenticationBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/> to add the authentication to.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/> with the Azure Container App authentication added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="builder"/> is null.</exception>
    public static AuthenticationBuilder AddAzureContainerAppAuthentication(
        this AuthenticationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        _ = builder
            .AddScheme<AzureContainerAppMicrosoftAuthenticationOptions, AzureContainerAppAuthenticationHandler<AzureContainerAppMicrosoftAuthenticationOptions>>(
            AzureContainerAppMicrosoftAuthenticationOptions.DefaultScheme,
            options => { });
        _ = builder.Services.AddOptions<AzureContainerAppMicrosoftAuthenticationOptions>();
        return builder;
    }
}