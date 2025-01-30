using Core.Data;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Serilog;

namespace Core.Helper
{
    public static class TestUtils
    {
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
