using Business.ApplicationContext;
using Business.ApplicationInterface;
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
            InsightsPage insightPage = new(Driver!);
            InsightContext insightContext = new(insightPage);

            new InsightContext(insightPage)
                .ClickInsight()
                .SwipeCarousel();


            string mainPageArticleTextTrimmed = insightContext.GetMainPageArticleTextTrim();


            new InsightContext(insightPage)
                .ClickReadMore();


            Log.Information("The Read More button in the carousel clicked");
            Log.Information("Insight page interactions completed successfully");

            new InsightValidation(insightPage)
                .ValidateMainPageArticleTextTrimIsEqualToInsideArticleText(mainPageArticleTextTrimmed);
        }
    }
}
