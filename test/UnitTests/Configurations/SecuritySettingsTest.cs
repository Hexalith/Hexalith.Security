namespace UnitTests.Configurations;

using System.Text.Json;

using FluentAssertions;

using Hexalith.DaprIdentityStore.Configurations;
using Hexalith.Extensions.Helpers;
using Hexalith.Security.Application.Configurations;
using Hexalith.TestMocks;

using Microsoft.Extensions.Configuration;

public class SecuritySettingsTest : SerializationTestBase
{
    public static Dictionary<string, string> TestSettings => new()
        {
            { "Hexalith:Security:Disabled", "true" },
        };

    [Fact]
    public void GetSettingsFromConfigurationShouldSucceed()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(TestSettings)
            .Build();
        SecuritySettings settings = configuration.GetSettings<SecuritySettings>();
        _ = settings.Should().NotBeNull();
        _ = settings.Disabled.Should().BeTrue();
    }

    [Fact]
    public void ShouldDeserialize()
    {
        // Arrange
        string json = "{ \"Disabled\": true}";

        // Act
        SecuritySettings settings = JsonSerializer.Deserialize<SecuritySettings>(json);

        // Assert
        _ = settings.Should().NotBeNull();
        _ = settings.Disabled.Should().BeTrue();
    }

    public override object ToSerializeObject() => new SecuritySettings
    {
        Disabled = true,
    };
}