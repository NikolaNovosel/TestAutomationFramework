using Business.ApplicationContext;
using Business.Validation;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{
    /// <summary>
    /// Test class for Insight page functionality
    /// </summary
    internal class InsightTest : Test
    {
        // Tests Insight page interactions and article consistency across pages
        [Test]
        public void TestCase4()
        {
            InsightContext insightContext = new(Driver!);

            new InsightContext(Driver!)
                .ClickInsight()
                .SwipeCarousel();


            string mainPageArticleTextTrimmed = insightContext.GetMainPageArticleTextTrim();


            new InsightContext(Driver!)
                .ClickReadMore();


            Log.Information("The Read More button in the carousel clicked");
            Log.Information("Insight page interactions completed successfully");

            new InsightValidation(Driver!)
                .ValidateMainPageArticleTextTrimIsEqualToInsideArticleText(mainPageArticleTextTrimmed);
        }
    }
}
