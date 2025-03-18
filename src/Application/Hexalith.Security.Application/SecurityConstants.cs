namespace Hexalith.Security.Application;

/// <summary>
/// Contains the security constants.
/// </summary>
public static class SecurityConstants
{
    /// <summary>
    /// Gets the header name for the client principal ID.
    /// </summary>
    public static string ClientPrincipalHeader => "X-MS-CLIENT-PRINCIPAL";

    /// <summary>
    /// Gets the header name for the client principal identity provider.
    /// </summary>
    public static string ClientPrincipalIdentityProviderHeader => "X-MS-CLIENT-PRINCIPAL-IDP";

    /// <summary>
    /// Gets the header name for the client principal ID.
    /// </summary>
    public static string ClientPrincipalIdHeader => "X-MS-CLIENT-PRINCIPAL-ID";

    /// <summary>
    /// Gets the header name for the client principal name.
    /// </summary>
    public static string ClientPrincipalNameHeader => "X-MS-CLIENT-PRINCIPAL-NAME";

    /// <summary>
    /// Gets the header name for the client principal roles.
    /// </summary>
    public static string ClientPrincipalRolesHeader => "X-MS-CLIENT-PRINCIPAL-ROLES";

    /// <summary>
    /// Gets the header name for the partition ID.
    /// </summary>
    public static string PartitionHeader => "HEXALITH-PARTITION-ID";
}