using Business.ApplicationInterface;
using Core.Helper;
using FluentAssertions;
using JetBrains.Annotations;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;

namespace Business.Validation
{
    /// <summary>
    /// Provides validation logic for functionality related to the Careers page.
    /// This class is responsible for verifying job title text and related behaviors.
    /// </summary>
    public class CareersValidation
    {
        // Private field to store an instance of the CareersPage
        private readonly CareersPage _careersPage;

        // Constructor takes an IWebDriver instance as a parameter, which is used to initialize the CareersPage
        public CareersValidation(IWebDriver driver)
        {
            _careersPage = new (driver);
        }

        // Returns the job title text from the Careers page.
        private string GetCareersArticleText() => _careersPage.GetCareersArticleText();

        // Validates that the job title text contains the specified keyword.
        [AssertionMethod]
        public CareersValidation ValidateCareersArticleTextContainKeyword(string keyword)
        {
            try
            {
                GetCareersArticleText().Should().Contain(keyword);
                Log.Information
                (@$"Successfully validate that the article text ""{GetCareersArticleText()}"" contains the keyword ""{keyword}""");
            }
            catch (AssertionException)
            {
                Log.Error
                (@$"Failed to validate keyword ""{keyword}"" in article text ""{GetCareersArticleText()}"".");

                throw;
            }

            return this;
        }
    }
}