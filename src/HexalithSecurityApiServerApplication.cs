namespace Hexalith.Security.ApiServer;

using System;
using System.Collections.Generic;

using Hexalith.Application.Modules.Applications;
using Hexalith.Extensions.Helpers;
using Hexalith.Security.Application;
using Hexalith.UI.ApiServer;

/// <summary>
/// Represents a server application.
/// </summary>
public class HexalithSecurityApiServerApplication : HexalithApiServerApplication
{
    private static readonly string _version = string.Empty;

    /// <inheritdoc/>
    public override IEnumerable<Type> ApiServerModules => [
        typeof(HexalithUIComponentsApiServerModule),
        typeof(HexalithSecurityApiServerModule)];

    /// <inheritdoc/>
    public override string Id => $"{HexalithSecurityApplicationInformation.Id}.{ApplicationType}";

    /// <inheritdoc/>
    public override string Name => $"{HexalithSecurityApplicationInformation.Name} {ApplicationType}";

    /// <inheritdoc/>
    public override string ShortName => HexalithSecurityApplicationInformation.ShortName;

    /// <inheritdoc/>
    public override string Version => string.IsNullOrWhiteSpace(_version)
        ? typeof(HexalithSecurityApiServerModule).GetAssemblyVersion()
        : _version;
}