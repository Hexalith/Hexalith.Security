// <copyright file="Program.cs" company="Hexalith SAS Paris France">
//     Copyright (c) Hexalith SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

using Hexalith.Infrastructure.AspireService.Hosting.Helpers;

using Microsoft.Extensions.Configuration;

HexalithDistributedApplication app = new(args);

app.Builder.AddForwardedHeaders();

if (app.Builder.ExecutionContext.IsRunMode)
{
    Console.WriteLine($"Starting environment {app.Builder.Environment.EnvironmentName}");
    _ = app
        .Builder
        .AddExecutable("dapr-dashboard", "dapr", ".", "dashboard")
        .WithHttpEndpoint(port: 8080, targetPort: 8080, name: "dashboard-http", isProxied: false);
}

app.Builder.Configuration.AddUserSecrets<Program>();

if (app.IsProjectEnabled<Projects.HexalithApp_WebServer>())
{
    _ = app
        .AddProject<Projects.HexalithApp_WebServer>("securityweb")
        .WithEnvironmentFromConfiguration("APP_API_TOKEN")
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Microsoft__Id", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Microsoft__Secret", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Google__Id", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Google__Secret", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Github__Id", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Github__Secret", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Facebook__Id", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Facebook__Secret", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__X__Id", false)
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__X__Secret", false)
        .WithEnvironmentFromConfiguration("EmailServer__ApplicationSecret")
        .WithEnvironmentFromConfiguration("EmailServer__FromEmail")
        .WithEnvironmentFromConfiguration("EmailServer__FromName");
}

if (app.IsProjectEnabled<Projects.HexalithApp_ApiServer>())
{
    _ = app
        .AddProject<Projects.HexalithApp_ApiServer>("securityapi")
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Microsoft__Id")
        .WithEnvironmentFromConfiguration("Hexalith__DaprIdentityStore__Microsoft__Secret")
        .WithEnvironmentFromConfiguration("EmailServer__ApplicationSecret")
        .WithEnvironmentFromConfiguration("EmailServer__FromEmail")
        .WithEnvironmentFromConfiguration("EmailServer__FromName");
}

await app
    .Builder
    .Build()
    .RunAsync()
    .ConfigureAwait(false);