using Core.Data;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Serilog;

namespace Core.Helper
{
    public class TestUtils(IWebDriver driver)
    {
        // Determine if GitActions path
        public static bool IsGitActions() => Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";

        // Checks if the current test  is "ApiTest"
        public static bool IsNotApiTestRunning()
        {
            return !TestContext.CurrentContext.Test.ClassName!.EndsWith("ApiTest");
        }

        // Checks if the current test case is "TestCase4"
        public static bool IsTestCase4Running()
        { 
            return TestContext.CurrentContext.Test.Name is "TestCase4";
        }

        // Indicates whether the last executed test failed
        public static bool HasTestFailed()
        {
            return TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;
        }

        // Configures and creates a logger instance for writing ui logs to console and a rolling log file.
        public static void GetUiLog()
        {
             Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(Location.UiLogs, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        // Configures and creates a logger instance for writing api logs to console and a rolling log file.
        public static void GetApiLog()
        {
            Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File(Location.ApiLogs, rollingInterval: RollingInterval.Day)
           .CreateLogger();
        }

        // Take screenshot method
        public TestUtils TakeScreenShot()
        {
            var screenshot = ((ITakesScreenshot)driver!).GetScreenshot();
            var screenshotPath = Path.Combine(Location.ScreenShot, "screenshot", $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotPath);

            return this;
        }
    }
}
