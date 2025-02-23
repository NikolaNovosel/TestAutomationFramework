using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Core.Helper;
using Core.Data;

namespace Core.Singleton
{
    /// <summary>
    /// Singleton class for managing WebDriver instances.
    /// </summary>
    public class DriverSingleton
    {
        // Static WebDriver instance shared across the application
        private static IWebDriver? _driver;

        // Private constructor to prevent instantiation
        private DriverSingleton()
        {

        }

        // Switches between Chrome and Firefox based on the test case
        public static IWebDriver SwitchBetweenChromeAndFirefox()
        {
            if (TestUtils.IsTestCase4Running())
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                _driver = new FirefoxDriver(DriverOption.GetFirefoxOptions());
                return _driver;
            }

            else
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                _driver = new ChromeDriver(DriverOption.GetChromeOptions());
                return _driver;
            }
        }

        // Returns a WebDriver instance for the specified browser
        public static IWebDriver GetDriver<T>() where T : IWebDriver, new()
        {
            if (typeof(T) == typeof(ChromeDriver))
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                _driver = new ChromeDriver(DriverOption.GetChromeOptions());
                return _driver;
            }

            if (typeof(T) == typeof(EdgeDriver))
            {
                new DriverManager().SetUpDriver(new EdgeConfig());
                _driver = new EdgeDriver(DriverOption.GetEdgeOptions());
                return _driver;
            }

            if (typeof(T) == typeof(FirefoxDriver))
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                _driver = new FirefoxDriver(DriverOption.GetFirefoxOptions());
                return _driver;
            }
            else
            {
                throw new NotSupportedException($"Browser type '{typeof(T).Name}' is not supported.");
            }
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
            _driver!.Url = ConfigProvider.UiUrl;
        }
    }
}
