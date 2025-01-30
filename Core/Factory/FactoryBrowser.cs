using Core.Data;
using Core.Helper;
using OpenQA.Selenium;

namespace Core.Factory
{
    /// <summary>
    /// Provides a factory pattern implementation for creating and managing browser instances.
    /// </summary>
    public class FactoryBrowser
    {
        // Static WebDriver instance shared across the application
        private static IWebDriver? _driver;

        // Private constructor to enforce static usage.
        private FactoryBrowser()
        {
            
        }

        // Switches between Chrome and Firefox based on test condition.
        public static IWebDriver SwitchBetweenChromeAndFirefox()
        {
            if (TestUtils.IsTestCase4Running)
            {
                IBrowser browser = new FirefoxBrowser();
                browser.GetDriverManager();
                _driver = browser.GetDriver(browser.GetDriverOptions());
                return _driver;
            }
            else
            {
                IBrowser browser = new ChromeBrowser();
                browser.GetDriverManager();
                _driver = browser.GetDriver(browser.GetDriverOptions());
                return _driver;
            }
        }

        // Returns a browser instance based on the provided driver kind.
        public static IWebDriver GetBrowser(DriverKind driver)
        {
            IBrowser browser = SwitchBrowser(driver);
            browser.GetDriverManager();
            _driver = browser.GetDriver(browser.GetDriverOptions());
            return _driver;
        }

        // Disposes the WebDriver instance
        public static void Dispose()
        {
            _driver?.Dispose();
        }

        // Manage the WebDriver window
        public static void ManageWindow()
        {
            _driver?.Manage().Window.Maximize();
        }

        // Set the WebDriver Url
        public static void GetUrl()
        {
            _driver!.Url = ConfigProvider.Url;
        }

        // Returns the appropriate browser instance based on the driver kind.
        private static IBrowser SwitchBrowser(DriverKind browser)
        {
            switch (browser)
            {
                case DriverKind.Chrome:
                    return new ChromeBrowser();
                case DriverKind.Edge:
                    return new EdgeBrowser();
                case DriverKind.FireFox:
                    return new FirefoxBrowser();
                default:
                    throw new ArgumentException($"Invalid status code: {browser}");
            }
        }
    }
}
