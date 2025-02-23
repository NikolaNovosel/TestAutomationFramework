using Microsoft.Extensions.Configuration;

namespace Core.Data
{
    /// </summary>
    /// Class for reading the app config data for testing purposes
    /// </summary>
    public static class ConfigProvider
    {
        // Initialize a ConfigurationBuilder and add the specified JSON configuration file
        private static readonly IConfigurationBuilder _builder = new ConfigurationBuilder().AddJsonFile(Location.JsonAppSettings);

        // Build the configuration and assign it to the Configuration property
        private static readonly IConfiguration ConfigReader = _builder.Build();

        // Provide access to Url section in appsettings.json
        private static readonly IConfiguration GetUrl = ConfigReader.GetSection("url");

        // Provide path to the GitActions downloaded directory
        public static readonly string GitActionsDownloadDir = ConfigReader["runnerDownloadDir"]!;

        // Provide the downloaded file name
        public static readonly string? FileName = ConfigReader["fileName"];

        // Provide the WebDriver url
        public static readonly string? UiUrl = GetUrl["ui"];

        // Provide the Api url
        public static readonly string? ApiUrl = GetUrl["api"];

        // Provide the Api endpoint users
        public static readonly string? Users = ConfigReader["endpoint:0"];

        // Provide the Api endpoint invalidendpoint
        public static readonly string? Invalid = ConfigReader["endpoint:1"];
    }
}
