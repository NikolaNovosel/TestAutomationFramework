using Business.ApplicationInterface;
using FluentAssertions;
using JetBrains.Annotations;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;

namespace Business.Validation
{
    /// <summary>
    /// Provides validation logic for search functionality, using a <see cref="SearchPage"/> instance.
    /// This class is responsible for verifying search results, input validation, and related behaviors.
    /// </summary>
    public class SearchValidation
    {
        // Private field to store an instance of the SearchPage
        private readonly SearchPage _searchPage;

        // Constructor takes an IWebDriver instance as a parameter, which is used to initialize the SearchPage
        public SearchValidation(IWebDriver driver)
        {
            _searchPage = new(driver);
        }

        // Check if the last 20th link is visible
        public bool HasLastLink() => _searchPage.HasLastLink();

        // Checks if all the links containing the keyword 
        public bool CheckIfAllLinksContainKeyword(string keyword) => _searchPage.CheckIfAllLinksContainKeyword(keyword);

        // Validates that not all links contain the keyword "BLOCKCHAIN" and Automation
        [AssertionMethod]
        public SearchValidation ValidateAllLinksNotContainOtherKeywords(string keyword)
        {
            try
            {
                if (keyword != "Cloud")
                {
                    CheckIfAllLinksContainKeyword(keyword).Should().BeFalse();
                    Log.Information(@$"Successfully validate that not all links contain the keyword: ""{keyword}""");
                }
            }
            catch (AssertionException)
            {
                Log.Error(@$"Failed to validate that not all links contain the keyword: ""{keyword}""");

                throw;
            }

            return this;
        }

        // Validates that all links contain the keyword "Cloud"
        [AssertionMethod]
        public SearchValidation ValidateAllLinksContainTheKeywordCloud(string keyword)
        {
            try
            {
                if (keyword == "Cloud")
                {
                    CheckIfAllLinksContainKeyword(keyword).Should().BeTrue();
                    Log.Information(@$"Successfully validate that all links contain the keyword: ""{keyword}""");
                }
            }
            catch (AssertionException)
            {
                Log.Error(@$"Failed to validate that all links contain the keyword: ""{keyword}""");

                throw;
            }

            return this;
        }

        // Asserts the last link in search results is displayed  
        [AssertionMethod]
        public SearchValidation ValidateLastLinkResultsDisplayed()
        {
            try
            {
                HasLastLink().Should().BeTrue();
                Log.Information(@$"Successfully validated that all links, including the last one, are included in the validation");
            }
            catch (WebDriverTimeoutException)
            {
                Log.Error(@$"Failed to validate that all links, including the last one, are included in the validation");

                throw;
            }

            return this;
        }
    }
}
