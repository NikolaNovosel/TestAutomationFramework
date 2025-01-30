using Business.ApplicationInterface;
using FluentAssertions;
using JetBrains.Annotations;
using Serilog;
using NUnit.Framework;

namespace Business.Validation
{
    /// <summary>
    /// Provides validation logic for Insight page functionality, using a <see cref="InsightsPage"/> instance.
    /// This class is responsible for verifying search results, input validation, and related behaviors.
    /// </summary>
    public class InsightValidation(InsightsPage insightPage)
    {
        // Returns the trimmed text of the main page article
        public string GetMainPageArticleTextTrim() => insightPage.GetMainPageArticleTextTrim();

        // Returns the text of the inside article
        public string GetInsideArticleText() => insightPage.GetInsideArticleText();

        /// Validates that the trimmed text of the main page article matches the text of the inside article.
        [AssertionMethod]
        public InsightValidation ValidateMainPageArticleTextTrimIsEqualToInsideArticleText(string mainPageArticleTextTrim)
        {
            try
            {
                mainPageArticleTextTrim.Should().Be(GetInsideArticleText());
                Log.Information
                    (@$"Successfully validate that the main page article: ""{mainPageArticleTextTrim}"" 
                    is equal to the inside article: ""{GetInsideArticleText()}""");
            }
            catch (AssertionException)
            {
                Log.Error
                    (@$"Failed to validate that the main page article: ""{mainPageArticleTextTrim}"" 
                    is equal to the inside article:  ""{GetInsideArticleText()}""");

                throw;
            }

            return this;
        }
    }
}
