// <copyright file="HexalithApplicationTest.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Tests.Modules;

using Hexalith.Application.Modules.Applications;
using Hexalith.Security.WebApp;
using Hexalith.Security.WebServer;

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
        _ = HexalithApplication.WebAppApplication.ShouldBeOfType<HexalithSecurityWebAppApplication>();
        _ = HexalithApplication.WebAppApplication.WebAppModules.ShouldNotBeNull();
        HexalithApplication.WebAppApplication.WebAppModules.Count().ShouldBe(2);
        HexalithApplication.WebAppApplication.Modules.Count().ShouldBe(2);
        HexalithApplication.WebAppApplication.WebAppModules.ShouldContain(typeof(HexalithSecurityWebAppModule));
        HexalithApplication.WebAppApplication.Modules.ShouldContain(typeof(HexalithSecurityWebAppModule));
    }

    /// <summary>
    /// Verifies that the WebServer application returns the correct server module types.
    /// </summary>
    [Fact]
    public void HexalithApplicationShouldReturnWebServerModuleTypes()
    {
        _ = HexalithApplication.WebServerApplication.ShouldNotBeNull();
        _ = HexalithApplication.WebServerApplication.ShouldBeOfType<HexalithSecurityWebServerApplication>();
        _ = HexalithApplication.WebServerApplication.WebServerModules.ShouldNotBeNull();
        HexalithApplication.WebServerApplication.WebServerModules.Count().ShouldBe(2);
        HexalithApplication.WebServerApplication.Modules.Count().ShouldBe(2);
        HexalithApplication.WebServerApplication.WebServerModules.ShouldContain(typeof(HexalithSecurityWebServerModule));
        HexalithApplication.WebServerApplication.Modules.ShouldContain(typeof(HexalithSecurityWebServerModule));
    }
}