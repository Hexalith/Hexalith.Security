# Hexalith.Security

## Overview

Hexalith.Security is a comprehensive security framework for .NET applications providing authentication, authorization, and identity management capabilities. Built with modern C# and Blazor, it offers a robust approach to implementing security in web applications, API servers, and microservices.

## Build Status

[![License: MIT](https://img.shields.io/github/license/hexalith/hexalith.Security)](https://github.com/hexalith/hexalith/blob/main/LICENSE)
[![Discord](https://img.shields.io/discord/1063152441819942922?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discordapp.com/channels/1102166958918610994/1102166958918610997)

[![Coverity Scan Build Status](https://scan.coverity.com/projects/31529/badge.svg)](https://scan.coverity.com/projects/hexalith-hexalith-Security)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/d48f6d9ab9fb4776b6b4711fc556d1c4)](https://app.codacy.com/gh/Hexalith/Hexalith.Security/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=Hexalith_Hexalith.Security&metric=bugs)](https://sonarcloud.io/summary/new_code?id=Hexalith_Hexalith.Security)

[![Build status](https://github.com/Hexalith/Hexalith.Security/actions/workflows/build-release.yml/badge.svg)](https://github.com/Hexalith/Hexalith.Security/actions)
[![NuGet](https://img.shields.io/nuget/v/Hexalith.Security.svg)](https://www.nuget.org/packages/Hexalith.Security)
[![Latest](https://img.shields.io/github/v/release/Hexalith/Hexalith.Security?include_prereleases&label=preview)](https://github.com/Hexalith/Hexalith.Security/pkgs/nuget/Hexalith.Security)

## Architecture

The Hexalith.Security project follows a modular architecture with clear separation of concerns:

### Core Components

- **Abstractions**: Defines interfaces, models, and contracts for security features
- **Application**: Business logic and services for security functionality
- **Infrastructure**: Implementation of data access and external service integration
- **Presentation**: UI components and pages for user interactions
- **Modules**: Integration modules for different application types (WebApp, WebServer, ApiServer)

### Integration with Hexalith Framework

The security module integrates with:

- **Hexalith.IdentityStores**: For identity storage and management
- **Hexalith.Application**: For application module integration
- **Hexalith.Infrastructure.DaprRuntime**: For distributed application runtime support

## Modules

### WebApp Module (`HexalithSecurityWebAppModule`)

Client-side authentication and authorization for Blazor WebAssembly applications:

```csharp
// Program.cs
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// ...
HexalithSecurityWebAppModule.AddServices(builder.Services, builder.Configuration);
```

### WebServer Module (`HexalithSecurityWebServerModule`) 

Server-side authentication and authorization:

```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);
// ...
builder.Services.AddModule<HexalithSecurityWebServerModule>(builder.Configuration);

var app = builder.Build();
// ...
app.UseModule<HexalithSecurityWebServerModule>();
app.UseSecurity<HexalithSecurityWebServerModule>();
```

### ApiServer Module (`HexalithSecurityApiServerModule`)

Security for API-focused applications:

```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);
// ...
builder.Services.AddModule<HexalithSecurityApiServerModule>(builder.Configuration);
```

## Security Features

- **Authentication**: ASP.NET Core Authentication, multiple schemes, Dapr-based authentication
- **Authorization**: Policy-based, role-based access control
- **Predefined Security Roles**: Owner, Contributor, Reader
- **Predefined Security Policies**: For respective roles

## Repository Structure

The repository is organized as follows:

- [src](./src/README.md) Is the source code directory of your project.
- [src/libraries](./src/libraries/README.md) Is the source code directory where you will add your Nuget package projects.
- [src/examples](./src/examples/README.md) Contains example implementations of your projects.
- [src/servers](./src/servers/README.md) Is the source code directory where you will add your Docker container projects.
- [src/aspire](./src/aspire/README.md) Is the source code directory where you will add your Aspire project.
- [test](./test/README.md) Contains test projects for your packages.
- [Hexalith.Builds](./Hexalith.Builds/README.md) Contains shared build configurations and tools.

## Getting Started

### Prerequisites

- [Hexalith.Builds](https://github.com/Hexalith/Hexalith.Builds)
- [Hexalith.IdentityStores](https://github.com/Hexalith/Hexalith.IdentityStores)
- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later
- [PowerShell 7](https://github.com/PowerShell/PowerShell) or later
- [Git](https://git-scm.com/)

### Installation

Add the Hexalith.Security NuGet package to your project:

```powershell
dotnet add package Hexalith.Security
```

### Configuration

Configure security settings in your `appsettings.json`:

```json
{
  "Security": {
    "Disabled": false
  }
}
```

## Examples

### Protecting a Blazor Page

```razor
@page "/secure-page"
@attribute [Authorize]
<h1>Secure Page</h1>

<p>This page is only accessible to authenticated users.</p>
```

### Using Role-Based Authorization

```razor
@page "/admin-page"
@attribute [Authorize(Roles = SecurityRoles.Owner)]
<h1>Admin Page</h1>

<p>This page is only accessible to users with the Owner role.</p>
```

### Using Policy-Based Authorization

```razor
@page "/contributor-page"
@attribute [Authorize(Policy = SecurityPolicies.Contributors)]
<h1>Contributors Page</h1>

<p>This page is only accessible to users who can contribute.</p>
```

## Best Practices

1. Use predefined roles and policies whenever possible
2. Implement the principle of least privilege by assigning minimum required permissions
3. Validate authorization at both UI and API levels
4. Configure proper authentication mechanisms based on your application type
5. Use cascading authentication state in Blazor applications for optimal performance

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support and Community

For support, please open an issue on the [GitHub repository](https://github.com/Hexalith/Hexalith.Security).

Join our Discord community: [Hexalith Discord](https://discordapp.com/channels/1102166958918610994/1102166958918610997)
