using Core.Data;

namespace Core.Helper
{
    /// <summary>
    /// Class for validating file download functionality on the About page.
    /// </summary>
    public static class AboutHelper
    {
        // Timestamp marking the start of the file download wait period
        private static readonly DateTime _startTime = DateTime.Now;

        // Checks if the specified time (5 seconds) has elapsed since the start time
        private static bool HasTimeElapsed => DateTime.Now < _startTime.AddSeconds(5);

        // Checks if the file exists at the specified path
        private static bool DoesFileExist => File.Exists(ConfigProvider.FilePath);

        // Waits for the file to download within the specified time frame
        public static bool WaitForFileDownload()
        {
            while (HasTimeElapsed)
            {
                if (DoesFileExist)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
