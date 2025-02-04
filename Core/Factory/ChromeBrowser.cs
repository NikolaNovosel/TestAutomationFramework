using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Core.Data;

namespace Core.Factory
{
    /// <summary>
    /// Edge-specific implementation of the IBrowser interface
    /// </summary>
    internal class ChromeBrowser : IBrowser
    {
        /// Creates and returns an EdgeDriver instance with the specified options
        public IWebDriver GetDriver(DriverOptions driverOptions) => new ChromeDriver((ChromeOptions)driverOptions);

        /// Configures and returns Edge-specific driver options
        public DriverOptions GetDriverOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("headless");
            chromeOptions.AddUserProfilePreference("download.default_directory", ConfigProvider.DownloadDir);
            return chromeOptions;
        }

        /// Sets up and returns the Edge driver manager
        public string GetDriverManager() => new DriverManager().SetUpDriver(new ChromeConfig());
    }
}
