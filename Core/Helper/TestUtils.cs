using Core.Data;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Serilog;

namespace Core.Helper
{
    public static class TestUtils
    {
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

        // Configures and creates a logger instance for writing logs to console and a rolling log file.
        public static void GetLog()
        {
             Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(Location.Logs, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
    }
}
