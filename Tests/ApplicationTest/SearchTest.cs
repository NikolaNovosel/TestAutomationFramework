using Business.ApplicationContext;
using Business.Validation;
using Business.ApplicationInterface;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{
    /// <summary>
    /// Test class for search functionality
    /// </summary>
    internal class SearchTest : Test
    {
        // Tests search results for different keywords
        [Test, TestCaseSource(typeof(Test), nameof(SearchPage))]
        public void TestCase2(string keyword)
        {
            SearchPage searchPage = new(Driver!);
             
            new SearchContext(searchPage)
                .ClickMagnifierIcon()
                .SendKeysSearch(keyword)
                .ClickFindSearch()
                .ScroolToLastLink();

            Log.Information("Search page interactions completed successfully");

            new SearchValidation(searchPage)
                .ValidateAllLinksNotContainOtherKeywords(keyword)
                .ValidateAllLinksContainTheKeywordCloud(keyword)
                .ValidateLastLinkResultsDisplayed();
        }
    }
}
