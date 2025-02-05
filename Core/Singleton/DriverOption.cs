using Core.Data;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Core.Singleton
{
    /// <summary>
    /// Helper class for configuring Chrome, Firefox, and Edge driver options.
    /// </summary>
    public static class DriverOption
    {
        // Determine the correct download path
        private static readonly string _downloadDir = Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true"
            ? "/home/runner/work/TestAutomationFramework/TestAutomationFramework/Tests/Downloads"
            : ConfigProvider.DownloadDir;

        // Gets ChromeOptions for headless Chrome with downloads to TestData.DownloadDir
        internal static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("headless");
            chromeOptions.AddUserProfilePreference("download.default_directory", _downloadDir);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            chromeOptions.AddUserProfilePreference("safebrowsing.disable_download_protection", true);
            return chromeOptions;
        }

        // Gets FirefoxOptions for headless Firefox with downloads to TestData.DownloadDir
        internal static FirefoxOptions GetFirefoxOptions()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            firefoxOptions.SetPreference("browser.download.dir", _downloadDir);
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf,text/csv"); // Auto-download specific
            firefoxOptions.SetPreference("pdfjs.disabled", true); // Disable built-in PDF viewer
            firefoxOptions.SetPreference("browser.download.manager.showWhenStarting", false); // Hide download manager popup
            firefoxOptions.SetPreference("browser.download.manager.useWindow", false); // No separate download window
            firefoxOptions.SetPreference("browser.download.manager.focusWhenStarting", false); // Do not focus on downloads
            firefoxOptions.AddArgument("--headless");
            return firefoxOptions;
        }

        // Gets EdgeOptions for headless Edge with downloads to TestData.DownloadDir
        internal static EdgeOptions GetEdgeOptions()
        {
            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--no-sandbox");
            edgeOptions.AddArgument("--disable-dev-shm-usage");
            edgeOptions.AddArgument("--headless");
            edgeOptions.AddUserProfilePreference("download.default_directory", _downloadDir);
            return edgeOptions;
        }
    }
}
