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

        // Provide Path to the downloaded file section
        private static readonly IConfiguration DownloadDir = ConfigReader.GetSection("downloadDir");

        // Provide path to the WebDriver downloaded directory
        public static readonly string WebDriverDownloadDir = DownloadDir["webDriver"]!;

        // Provide path to the GitActions downloaded directory
        public static readonly string GitActionsDownloadDir = DownloadDir["gitActions"]!;

        // Provide path to the GitActions screenshot directory
        public static readonly string GitActionsScreenshot = ConfigReader["gitActionsScreenshot"]!;

        // Provide the downloaded file name
        public static readonly string? FileName = ConfigReader["fileName"];

        // Provide the WebDriver url
        public static readonly string? Url = ConfigReader["url"];

        // Provide the Api url
        public static readonly string? Api = ConfigReader["api"];

        // Provide the Api endpoint users
        public static readonly string? Users = ConfigReader["endpoint:0"];

        // Provide the Api endpoint invalidendpoint
        public static readonly string? Invalid = ConfigReader["endpoint:1"];
    }
}
