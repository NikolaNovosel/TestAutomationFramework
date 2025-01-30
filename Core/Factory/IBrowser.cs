using OpenQA.Selenium;

namespace Core.Factory
{
    /// <summary>
    /// This interface ensures that all browser types provide methods for retrieving a web driver instance,
    /// configuring driver options, and managing the driver setup.
    /// </summary>
    internal interface IBrowser
    {
        /// Returns a configured web driver instance
        IWebDriver GetDriver(DriverOptions driverOptions);

        /// Returns browser-specific driver options
        DriverOptions GetDriverOptions();

        /// Sets up and returns driver manager details
        string GetDriverManager();
    }
}
