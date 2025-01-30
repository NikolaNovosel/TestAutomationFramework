using NUnit.Framework;
using OpenQA.Selenium;
using Core.Data;
using Core.Factory;
using Serilog;
using Core.Helper;
using OpenQA.Selenium.Firefox;
using Core.Singleton;

namespace Tests.ApplicationTest
{
    /// <summary>
    /// Test class for browser interactions, utilizing DriverSingleton and Data class for test data
    /// Initializes and tears down WebDriver within the Setup and TearDown methods
    /// </summary>
    internal class Test
    {
        // Deserializes and stores test data
        protected readonly static TestData? TestData = TestDataReader.DeserializeData();

        // Reads and stores search page parameters from a source
        protected readonly static IEnumerable<string> SearchPage = TestDataReader.ReadSearchPage();

        // Stores and access to the WebDriver instance
        private IWebDriver? _driver;

        // Provides access to the WebDriver instance
        protected IWebDriver? Driver => _driver;

        // Initializes the WebDriver instance
        [SetUp]
        public void Setup()
        {
            _driver = FactoryBrowser.SwitchBetweenChromeAndFirefox();
            FactoryBrowser.ManageWindow();
            FactoryBrowser.GetUrl();

            TestUtils.GetLog();
        }

        // Disposes of the WebDriver instance
        [TearDown]
        public void TearDown()
        {
            // Indicates whether the last executed test failed to consider screenshot
            if (TestUtils.HasTestFailed())
            {
                // Take screenshot method
                var screenshot = ((ITakesScreenshot)_driver!).GetScreenshot();
                var screenshotPath = Path.Combine(Location.ScreenShot, "screenshot", $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(screenshotPath);
            }

            Log.CloseAndFlush();

            FactoryBrowser.Dispose();
        }
    }
}
