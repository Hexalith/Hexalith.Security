namespace Hexalith.Security.Servers.Authentications;

using System.Security.Claims;
using System.Text.Encodings.Web;

using Hexalith.Security.Application;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

/// <summary>
/// Authentication handler for Azure Container App.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AzureContainerAppAuthenticationHandler"/> class.
/// </remarks>
/// <param name="options">The options monitor.</param>
/// <param name="logger">The logger factory.</param>
/// <param name="encoder">The URL encoder.</param>
public class AzureContainerAppAuthenticationHandler(
        IOptionsMonitor<AzureContainerAppAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : AuthenticationHandler<AzureContainerAppAuthenticationOptions>(options, logger, encoder)
{
    /// <inheritdoc/>
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Check if the request contains the Azure Container App headers
        _ = Context.Request.Headers.TryGetValue(SecurityConstants.ClientPrincipalHeader, out Microsoft.Extensions.Primitives.StringValues principalIdValues);
        string? principalId = principalIdValues;
        if (string.IsNullOrEmpty(principalId))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        List<Claim> claims = [];
        claims.Add(new Claim(ClaimTypes.NameIdentifier, principalId));

        // Get the user information from the headers
        _ = Context.Request.Headers.TryGetValue(SecurityConstants.ClientPrincipalNameHeader, out Microsoft.Extensions.Primitives.StringValues principalNameValues);
        _ = Context.Request.Headers.TryGetValue(SecurityConstants.ClientPrincipalIdentityProviderHeader, out Microsoft.Extensions.Primitives.StringValues identityProviderValues);
        string? principalName = principalNameValues;
        string? identityProvider = identityProviderValues;

        // Add the user information to the claims
        if (!string.IsNullOrEmpty(principalName))
        {
            claims.Add(new Claim(ClaimTypes.Name, principalName));
        }

        if (!string.IsNullOrEmpty(identityProvider))
        {
            claims.Add(new Claim("identityProvider", identityProvider));
        }

        // Add roles if available
        if (Context.Request.Headers.TryGetValue(SecurityConstants.ClientPrincipalRolesHeader, out Microsoft.Extensions.Primitives.StringValues roles) &&
            !string.IsNullOrEmpty(roles))
        {
            string[] rolesList = roles.ToString().Split(',');
            foreach (string role in rolesList)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Trim()));
            }
        }

        // Create the principal and ticket
        ClaimsIdentity identity = new(claims, AzureContainerAppAuthenticationOptions.AuthenticationType);
        ClaimsPrincipal principal = new(identity);
        AuthenticationTicket ticket = new(principal, AzureContainerAppAuthenticationOptions.Scheme);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}