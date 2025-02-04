using Business.ApplicationContext;
using Business.Validation;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{    
    /// <summary>
    /// Test class for Careers page functionality
    /// </summary>
    [Category("UI")]
    internal class CareersTest : Test
    {
        // Test Careers page interactions and article content
        [Test]
        public void TestCase1()
        {
            new CareersContext(Driver!)
                .ClickCareers()
                .SendKeysKeyword(TestData!.CareersPage)
                .ClickLocation()
                .ClickAllLocations()
                .ClickRemote()
                .ClickFindCareers()
                .ClickViewAndApply();

            Log.Information("The latest job result opened");
            Log.Information("Careers page interactions completed successfully");

            new CareersValidation(Driver!)
                .ValidateCareersArticleTextContainKeyword(TestData!.CareersPage);
        }
    }
}
