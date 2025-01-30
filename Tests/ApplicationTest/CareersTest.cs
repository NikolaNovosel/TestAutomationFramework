using Business.ApplicationContext;
using Business.ApplicationInterface;
using Business.Validation;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{    
    /// <summary>
    /// Test class for Careers page functionality
    /// </summary>
    internal class CareersTest : Test
    {
        // Test Careers page interactions and article content
        [Test]
        public void TestCase1()
        {
            CareersPage careersPage = new(Driver!);

            new CareersContext(careersPage)
                .ClickCareers()
                .SendKeysKeyword(TestData!.CareersPage)
                .ClickLocation()
                .ClickAllLocations()
                .ClickRemote()
                .ClickFindCareers()
                .ClickViewAndApply();

            Log.Information("The latest job result opened");
            Log.Information("Careers page interactions completed successfully");

            new CareersValidation(careersPage)
                .ValidateCareersArticleTextContainKeyword(TestData!.CareersPage);
        }
    }
}
