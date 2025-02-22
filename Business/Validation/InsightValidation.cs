using Business.ApplicationInterface;
using FluentAssertions;
using Serilog;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Business.Validation
{
    /// <summary>
    /// Provides validation logic for Insight page functionality, using a <see cref="InsightsPage"/> instance.
    /// This class is responsible for verifying search results, input validation, and related behaviors.
    /// </summary>
    public class InsightValidation
    {
        // Private field to store an instance of the InsightPage
        private readonly InsightsPage _insightPage;

        // Constructor takes an IWebDriver instance as a parameter, which is used to initialize the InsightPage
        public InsightValidation(IWebDriver driver)
        {
            _insightPage = new(driver);
        }

        // Returns the trimmed text of the main page article
        public string GetMainPageArticleTextTrim() => _insightPage.GetMainPageArticleTextTrim();

        // Returns the text of the inside article
        public string GetInsideArticleText() => _insightPage.GetInsideArticleText();

        /// Validates that the trimmed text of the main page article matches the text of the inside article.
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
