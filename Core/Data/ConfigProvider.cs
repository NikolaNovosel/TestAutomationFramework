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
        private static readonly IConfiguration Config = _builder.Build();

        // Provide Path to the downloaded file
        public static readonly string FilePath =
        Path.Combine(Config["downloadDir"]!, Config["fileName"]!);

        // Provide path to the downloaded directory
        public static readonly string DownloadDir = Path.Combine(Config["downloadDir"]!);

        // Provide the downloaded file name
        public static readonly string? FileName = Config["fileName"];

        // Provide the WebDriver url
        public static readonly string? Url = Config["url"];

        // Provide the Api url
        public static readonly string? Api = Config["api"];
    }
}
