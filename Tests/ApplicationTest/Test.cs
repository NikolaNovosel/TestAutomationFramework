using NUnit.Framework;
using OpenQA.Selenium;
using Core.Data;
using Core.Factory;
using Serilog;
using Core.Helper;
using Core.Api;

namespace Tests.ApplicationTest
{
    /// <summary>
    /// Test class for browser interactions, utilizing DriverSingleton and Data class for test data
    /// Initializes and tears down WebDriver within the Setup and TearDown methods
    /// </summary>
    internal abstract class Test
    {
        // Deserializes and stores test data
        protected readonly static TestData? TestData = TestDataReader.DeserializeData();

        // Reads and stores search page parameters from a source
        protected readonly static IEnumerable<string> SearchPage = TestDataReader.ReadSearchPage();

        // Stores and access to the WebDriver instance
        private IWebDriver? _driver;

        // Provides access to the WebDriver instance
        protected IWebDriver? Driver => _driver;

        // Stores and access to the WebDriver instance
        private UserClient? _userClient;

        // Provides access to the WebDriver instance
        protected UserClient? UserClient => _userClient;

        // Initializes the WebDriver instance
        [SetUp]
        public void Setup()
        {
            _userClient = new UserClient();

            if (TestUtils.IsNotApiTestRunning())
            {
                _driver = FactoryBrowser.SwitchBetweenChromeAndFirefox();
                FactoryBrowser.ManageWindow();
                FactoryBrowser.GetUrl();
            }

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
                new TestUtils(_driver!).TakeScreenShot();
            }

            if (TestUtils.IsNotApiTestRunning())
            {
                FactoryBrowser.Dispose();
            }

            Log.CloseAndFlush();
        }
    }
}
