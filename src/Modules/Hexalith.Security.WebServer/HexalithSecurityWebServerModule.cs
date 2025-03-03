﻿namespace Hexalith.Security.WebServer;

using System.Collections.Generic;
using System.Reflection;

using Hexalith.Application.Modules.Applications;
using Hexalith.Application.Modules.Modules;
using Hexalith.DaprIdentityStore.UI.Helpers;
using Hexalith.Extensions.Configuration;
using Hexalith.Extensions.Helpers;
using Hexalith.Security.Application;
using Hexalith.Security.Application.Configurations;
using Hexalith.Security.Application.Menu;
using Hexalith.Security.Servers.Controllers;
using Hexalith.Security.Servers.Helpers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

/// <summary>
/// Microsoft Security server module.
/// </summary>
public sealed class HexalithSecurityWebServerModule : IWebServerApplicationModule
{
    private static string? _version;

    /// <inheritdoc/>
    public IDictionary<string, AuthorizationPolicy> AuthorizationPolicies => new Dictionary<string, AuthorizationPolicy>();

    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => [];

    /// <inheritdoc/>
    public string Description => Name + " Module";

    /// <inheritdoc/>
    public string Id => $"{HexalithSecurityApplicationInformation.Id}.WebServer";

    /// <inheritdoc/>
    public string Name => $"{HexalithSecurityApplicationInformation.Name} Web Server";

    /// <inheritdoc/>
    public int OrderWeight => 0;

    /// <inheritdoc/>
    public IEnumerable<Assembly> PresentationAssemblies =>
    [
        GetType().Assembly,
        typeof(Hexalith.Security.WebApp.HexalithSecurityWebAppModule).Assembly,
        typeof(Hexalith.DaprIdentityStore.UI._Imports).Assembly,
        typeof(Hexalith.Security.UI.Components._Imports).Assembly,
        typeof(Hexalith.Security.UI.Pages._Imports).Assembly
    ];

    /// <inheritdoc/>
    public string Version => _version ??= GetType().Assembly.GetAssemblyVersion() ?? "1.0.0";

    /// <inheritdoc/>
    string IApplicationModule.Path => Path;

    private static string Path => HexalithSecurityApplicationInformation.ShortName;

    /// <summary>
    /// Adds services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        SecuritySettings settings = configuration.GetSettings<SecuritySettings>()
            ?? throw new InvalidOperationException($"Could not load settings section '{SecuritySettings.ConfigurationName()}'");
        if (settings.Disabled)
        {
            return;
        }

        _ = services
            .AddSecurityUIComponents()
            .AddControllers()
            .AddApplicationPart(typeof(UserPartitionController).Assembly)
            .AddDapr();

        _ = services
            .AddCascadingAuthenticationState()
            .AddDaprIdentityStoreUI()
            .AddSingleton(p => SecurityMenu.Menu)
            .ConfigureSettings<SecuritySettings>(configuration);
        _ = services
            .AddAuthorization(
                HexalithApplication.WebServerApplication?.ConfigureAuthorization()
                    ?? throw new InvalidOperationException("Web server application not initialized."));
    }

    /// <inheritdoc/>
    public void UseModule(object application)
    {
        ArgumentNullException.ThrowIfNull(application);
        if (application is not WebApplication app)
        {
            throw new InvalidOperationException($"Invalid builder type '{application.GetType().FullName}' for UseModule. The expected type is {typeof(WebApplication).FullName}.");
        }

        _ = app.MapAdditionalIdentityEndpoints();
    }

    /// <inheritdoc/>
    public void UseSecurity(object application)
    {
        ArgumentNullException.ThrowIfNull(application);
        if (application is not WebApplication app)
        {
            throw new InvalidOperationException($"Invalid builder type '{application.GetType().FullName}' for UseSecurity. The expected type is {typeof(WebApplication).FullName}.");
        }

        // initialize modules
        using IServiceScope scope = app.Services.CreateScope();
        IOptions<SecuritySettings> settings = scope.ServiceProvider.GetRequiredService<IOptions<SecuritySettings>>();

        // if (settings.Value.UseMsal)
        // {
        //    IWebHostEnvironment env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
        //    if (env.IsDevelopment())
        //    {
        //        _ = app.UseMiddleware<DevelopmentAuthenticationMiddleware>();
        //    }

        // _ = app.UseMiddleware<ContainerAppsAuthenticationMiddleware>();
        // }
        _ = app
            .UseAuthentication()
            .UseAuthorization();
    }
}