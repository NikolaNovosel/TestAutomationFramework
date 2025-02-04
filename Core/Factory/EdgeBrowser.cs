using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Core.Data;

namespace Core.Factory
{
    /// <summary>
    /// Edge-specific implementation of the IBrowser interface
    /// </summary>
    internal class EdgeBrowser : IBrowser
    {
        // Creates and returns an EdgeDriver instance with the specified options
        public IWebDriver GetDriver(DriverOptions driverOptions) => new EdgeDriver((EdgeOptions)driverOptions);

        // Configures and returns Edge-specific driver options
        public DriverOptions GetDriverOptions()
        {
            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--no-sandbox");
            edgeOptions.AddArgument("--disable-dev-shm-usage");
            edgeOptions.AddArgument("--headless");
            edgeOptions.AddUserProfilePreference("download.default_directory", ConfigProvider.DownloadDir);
            return edgeOptions;
        }

        // Sets up and returns the Edge driver manager
        public string GetDriverManager() => new DriverManager().SetUpDriver(new EdgeConfig());
    }
}
