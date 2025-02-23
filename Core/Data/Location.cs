using Core.Helper;

namespace Core.Data
{
    public static class Location
    {
        // Path to directory of the executing assembly
        private static readonly string _baseDir = AppDomain.CurrentDomain.BaseDirectory;

        // Path to main project directory
        private static readonly string _projectPath = Path.GetFullPath(Path.Combine(_baseDir, "..", "..", ".."));

        // Path to appsettings json
        public static readonly string JsonAppSettings = Path.Combine(_projectPath, "json", "appsettings.json");

        // Path to test data json
        public static readonly string JsonTestData = Path.Combine(_projectPath, "json", "testdata.json");

        // Path to ui log data text
        public static readonly string UiLogs = Path.Combine(_projectPath, "log_ui", "log.txt");

        // Path to api log data text
        public static readonly string ApiLogs = Path.Combine(_projectPath, "log_api", "log.txt");

        // Path to api log data text
        public static readonly string Download = Path.Combine(_projectPath, "download");

        // Provide the path to main project directory
        public static readonly string ScreenShot = _projectPath;

        // Determine the correct download path
        public static string DownloadDir => TestUtils.IsGitActions() ? ConfigProvider.GitActionsDownloadDir : Download;
    }
}
