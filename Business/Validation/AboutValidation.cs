using Core.Data;
using Core.Helper;
using Core.Singleton;
using FluentAssertions;
using JetBrains.Annotations;
using NUnit.Framework;
using Serilog;

namespace Business.Validation
{
    /// <summary>
    /// Provides validation logic for functionality related to the About page.
    /// This class is responsible for verifying file download behaviors.
    /// </summary>
    public class AboutValidation
    {
        // Validates that a file has been successfully downloaded.
        [AssertionMethod]
        public AboutValidation ValidateFileDownloaded()
        {
            try
            {
                AboutHelper.WaitForFileDownload().Should().BeTrue();
                Log.Information(@$"File: ""{ConfigProvider.FileName}"" downloaded successfully to: ""{Location.DownloadDir}""");
            }
            catch (AssertionException)
            {
                Log.Error(@$"Failed to validate the file: ""{ConfigProvider.FileName}"" is downloaded to: ""{Location.DownloadDir}""");

                throw;
            }

            return this;
        }
    }
}
