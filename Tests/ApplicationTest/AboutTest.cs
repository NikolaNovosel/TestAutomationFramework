using Business.ApplicationContext;
using Business.Validation;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{
    /// <summary>
    /// Test class for About page functionality
    /// </summary>
    internal class AboutTest : Test
    {
        // Tests About page interactions and file download
        [Test]
        public void TestCase3()
        {
            new AboutContext(Driver!)
                .ClickAbout()
                .ScrollToEpamAtGlance()
                .ClickDownload();

            Log.Information("The download button clicked");
            Log.Information("About page interactions completed successfully");

            new AboutValidation().ValidateFileDownloaded();
        }
    }
}
