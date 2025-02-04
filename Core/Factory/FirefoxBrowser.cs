using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Core.Data;
using OpenQA.Selenium.Edge;

namespace Core.Factory
{
    /// <summary>
    /// Firefox-specific implementation of the IBrowser interface
    /// </summary>
    internal class FirefoxBrowser : IBrowser
    {
        /// Creates and returns a FirefoxDriver instance with the specified options
        public IWebDriver GetDriver(DriverOptions driverOptions) => new FirefoxDriver((FirefoxOptions)driverOptions);

        /// Configures and returns Firefox-specific driver options
        public DriverOptions GetDriverOptions()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            firefoxOptions.SetPreference("browser.download.dir", ConfigProvider.DownloadDir);
            firefoxOptions.AddArgument("--headless");
            return firefoxOptions;
        }

        /// Sets up and returns the Firefox driver manager
        public string GetDriverManager() => new DriverManager().SetUpDriver(new FirefoxConfig());
    }
}
