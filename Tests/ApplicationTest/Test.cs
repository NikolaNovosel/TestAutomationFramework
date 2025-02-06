using NUnit.Framework;
using OpenQA.Selenium;
using Core.Data;
using Serilog;
using Core.Helper;
using Core.Api;
using Core.Singleton;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

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

        // Stores access to the WebDriver instance
        private IWebDriver? _driver;

        // Provides access to the WebDriver instance
        protected IWebDriver? Driver => _driver;

        // Stores access to the Rest instance
        private Rest? _rest;

        // Provides access to the Rest instance
        protected Rest? Rest => _rest;

        // Initializes Rest, WebDriver and Logger instances
        [SetUp]
        public void Setup()
        {
            // Indicates whether the last Api test is running to initialize WebDriver instance
            if (TestUtils.IsNotApiTestRunning())
            {
                _driver = DriverSingleton.GetDriver<FirefoxDriver>();
                DriverSingleton.ManageWindow();
                DriverSingleton.GetUrl();

                //Initialize Ui Logger
                TestUtils.GetUiLog();
            }
            else
            {
                //Initialize Rest
                _rest = new Rest();

                //Initialize Api Logger
                TestUtils.GetApiLog();
            }
        }

        // Disposes of the WebDriver and Logger instances
        [TearDown]
        public void TearDown()
        {
            // Indicates whether the last executed test failed to consider screenshot
            if (TestUtils.HasTestFailed() && TestUtils.IsNotApiTestRunning())
            {
                // Take screenshot method
                new TestUtils(_driver!).TakeScreenShot();
            }

            // Indicates whether the last Api test is running to dispose WebDriver instance
            if (TestUtils.IsNotApiTestRunning())
            {
                DriverSingleton.Dispose();
            }

            //Dispose Logger
            Log.CloseAndFlush();
        }
    }
}
