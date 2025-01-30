using NUnit.Framework;
using OpenQA.Selenium;
using Core.Data;
using Core.Factory;
using Serilog;
using Core.Helper;
using OpenQA.Selenium.Firefox;

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
            Testlogger.GetLog();
        }

        // Disposes of the WebDriver instance
        [TearDown]
        public void TearDown()
        {
            if (Testlogger.TestFailed)
            {
                Testlogger.TakeScreenShot(_driver!);
            }

            Log.CloseAndFlush();
            FactoryBrowser.Dispose();
        }
    }
}
