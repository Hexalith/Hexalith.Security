// <copyright file="HexalithApplicationTest.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Tests.Modules;

using Hexalith.Application.Modules.Applications;
using Hexalith.Security.Application.Configurations;
using Hexalith.Security.WebApp;
using Hexalith.Security.WebServer;
using Hexalith.UI.Components;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Shouldly;

using Xunit;

/// <summary>
/// Unit tests for the <see cref="HexalithApplication"/> class.
/// </summary>
public class HexalithApplicationTest
{
    /// <summary>
    /// Verifies that the WebApp application returns the correct client module types.
    /// </summary>
    [Fact]
    public void HexalithApplicationShouldReturnClientModuleTypes()
    {
        _ = HexalithApplication.WebAppApplication.ShouldNotBeNull();
        HexalithApplication.WebAppApplication.WebAppModules.Count().ShouldBe(2);
        HexalithApplication.WebAppApplication.Modules.Count().ShouldBe(2);
        HexalithApplication.WebAppApplication.WebAppModules.ShouldContain(typeof(HexalithSecurityWebAppModule));
        HexalithApplication.WebAppApplication.Modules.ShouldContain(typeof(HexalithSecurityWebAppModule));
    }

    /// <summary>
    /// Verifies that the WebServer application returns the correct server module types.
    /// </summary>
    [Fact]
    public void HexalithApplicationShouldReturnServerModuleTypes()
    {
        _ = HexalithApplication.WebServerApplication.ShouldNotBeNull();
        HexalithApplication.WebServerApplication.WebServerModules.Count().ShouldBe(2);
        HexalithApplication.WebServerApplication.Modules.Count().ShouldBe(2);
        HexalithApplication.WebServerApplication.WebServerModules.ShouldContain(typeof(HexalithSecurityWebServerModule));
        HexalithApplication.WebServerApplication.Modules.ShouldContain(typeof(HexalithSecurityWebServerModule));
    }

    /// <summary>
    /// Verifies that services from WebApp modules are correctly added to the service collection.
    /// </summary>
    [Fact]
    public void WebAppServicesFromModulesShouldBeAdded()
    {
        ServiceCollection services = [];
        Dictionary<string, string?> inMemorySettings = new()
        {
            { $"{SecuritySettings.ConfigurationName()}:Disabled", "false" },
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        HexalithApplication.AddWebAppServices(services, configuration);

        // Check that the client module services have been added by checking if Fluent UI ToastService has been added
        services.ShouldContain(s => s.ServiceType == typeof(MenuItemInformation));
        services.Count(s => s.ServiceType == typeof(MenuItemInformation)).ShouldBe(1);
    }
}