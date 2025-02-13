using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Core.Singleton;
using Core.Data;

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
            firefoxOptions.AddArgument("--headless");
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            firefoxOptions.SetPreference("browser.download.dir", Location.DownloadDir);
            return firefoxOptions;
        }

        /// Sets up and returns the Firefox driver manager
        public string GetDriverManager() => new DriverManager().SetUpDriver(new FirefoxConfig());
    }
}
