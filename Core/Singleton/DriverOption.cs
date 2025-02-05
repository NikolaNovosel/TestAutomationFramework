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
        // Determine if GitActions path
        public static bool IsGitActions() => Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";

        // Determine the correct download path
        private static readonly string _downloadDir = IsGitActions() ? ConfigProvider.GitActionsDownloadDir : ConfigProvider.WebDriverDownloadDir;

        // Provides the correct download path
        public static string DownloadDir => _downloadDir;

        // Gets ChromeOptions for headless Chrome with downloads to TestData.DownloadDir
        internal static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddUserProfilePreference("download.default_directory", _downloadDir);
            return chromeOptions;
        }

        // Gets FirefoxOptions for headless Firefox with downloads to TestData.DownloadDir
        internal static FirefoxOptions GetFirefoxOptions()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--no-sandbox");
            firefoxOptions.AddArgument("--disable-dev-shm-usage");
            firefoxOptions.AddArgument("--headless");
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            firefoxOptions.SetPreference("browser.download.dir", _downloadDir);
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
