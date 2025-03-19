namespace Hexalith.Security.Servers.Helpers;

using Hexalith.Security.Application.Configurations;
using Hexalith.Security.Servers.Authentications;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
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
    /// <param name="configuration">The configuration containing security settings.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/> with the Azure Container App authentication added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="builder"/> or <paramref name="configuration"/> is null.</exception>
    public static AuthenticationBuilder AddAzureContainerAppAuthentication(
        this AuthenticationBuilder builder,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configuration);

        SecuritySettings settings = configuration.GetSection(SecuritySettings.ConfigurationName()).Get<SecuritySettings>()
            ?? throw new InvalidOperationException($"Could not load settings section '{SecuritySettings.ConfigurationName()}'");

        if (settings.EasyAuthMicrosoft)
        {
            _ = builder
                .AddScheme<AzureContainerAppMicrosoftAuthenticationOptions, AzureContainerAppAuthenticationHandler<AzureContainerAppMicrosoftAuthenticationOptions>>(
                AzureContainerAppMicrosoftAuthenticationOptions.DefaultScheme,
                options => { });
            _ = builder.Services.AddOptions<AzureContainerAppMicrosoftAuthenticationOptions>();
        }

        if (settings.EasyAuthGithub)
        {
            _ = builder
                .AddScheme<AzureContainerAppGithubAuthenticationOptions, AzureContainerAppAuthenticationHandler<AzureContainerAppGithubAuthenticationOptions>>(
                AzureContainerAppGithubAuthenticationOptions.DefaultScheme,
                options => { });
            _ = builder.Services.AddOptions<AzureContainerAppGithubAuthenticationOptions>();
        }

        if (settings.EasyAuthFacebook)
        {
            _ = builder
                .AddScheme<AzureContainerAppFacebookAuthenticationOptions, AzureContainerAppAuthenticationHandler<AzureContainerAppFacebookAuthenticationOptions>>(
                AzureContainerAppFacebookAuthenticationOptions.DefaultScheme,
                options => { });
            _ = builder.Services.AddOptions<AzureContainerAppFacebookAuthenticationOptions>();
        }

        if (settings.EasyAuthGoogle)
        {
            _ = builder
                .AddScheme<AzureContainerAppGoogleAuthenticationOptions, AzureContainerAppAuthenticationHandler<AzureContainerAppGoogleAuthenticationOptions>>(
                AzureContainerAppGoogleAuthenticationOptions.DefaultScheme,
                options => { });
            _ = builder.Services.AddOptions<AzureContainerAppGoogleAuthenticationOptions>();
        }

        if (settings.EasyAuthX)
        {
            _ = builder
                .AddScheme<AzureContainerAppXAuthenticationOptions, AzureContainerAppAuthenticationHandler<AzureContainerAppXAuthenticationOptions>>(
                AzureContainerAppXAuthenticationOptions.DefaultScheme,
                options => { });
            _ = builder.Services.AddOptions<AzureContainerAppXAuthenticationOptions>();
        }

        return builder;
    }
}