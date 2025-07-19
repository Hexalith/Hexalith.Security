// <copyright file="HexalithSecurityWebAppModule.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.WebApp;

using System;
using System.Collections.Generic;
using System.Reflection;

using Hexalith.Application.Modules.Applications;
using Hexalith.Application.Modules.Modules;
using Hexalith.Extensions.Helpers;
using Hexalith.Security.Application;
using Hexalith.Security.Application.Configurations;
using Hexalith.Security.Application.Helpers;
using Hexalith.Security.Application.Menu;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Microsoft Security client module.
/// </summary>
public sealed class HexalithSecurityWebAppModule : IWebAppApplicationModule
{
    private static string? _version;

    /// <inheritdoc/>
    public IDictionary<string, AuthorizationPolicy> AuthorizationPolicies => SecurityModulePolicies.AuthorizationPolicies;

    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => [];

    /// <inheritdoc/>
    public string Description => Name + " Module";

    /// <inheritdoc/>
    public string Id => $"{HexalithSecurityApplicationInformation.Id}.WebApp";

    /// <inheritdoc/>
    public string Name => $"{HexalithSecurityApplicationInformation.Name} Web App";

    /// <inheritdoc/>
    public int OrderWeight => 0;

    /// <inheritdoc/>
    public IEnumerable<Assembly> PresentationAssemblies => [
        GetType().Assembly,
        typeof(UI.Components._Imports).Assembly,
        typeof(UI.Pages._Imports).Assembly
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
    /// <exception cref="InvalidOperationException">
    /// Thrown when the security settings section cannot be loaded or when the web application is not initialized.
    /// </exception>
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        SecuritySettings settings = configuration.GetSettings<SecuritySettings>()
            ?? throw new InvalidOperationException($"Could not load settings section '{SecuritySettings.ConfigurationName()}'");
        if (settings.Disabled)
        {
            return;
        }

        // Add authentication services
        _ = services
            .AddAuthorizationCore(HexalithApplication.WebAppApplication?.ConfigureAuthorization()
                    ?? throw new InvalidOperationException("Web application not initialized."))
            .AddCascadingAuthenticationState()
            .AddAuthenticationStateDeserialization()
            .AddScoped<BaseAddressAuthorizationMessageHandler>();

        _ = services.AddSingleton(SecurityMenu.Menu);
    }

    /// <inheritdoc/>
    public void UseModule(object application)
    {
    }
}