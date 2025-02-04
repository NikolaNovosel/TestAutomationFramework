using Business.ApplicationContext;
using Business.Validation;
using NUnit.Framework;
using Serilog;

namespace Tests.ApplicationTest
{
    /// <summary>
    /// Test class for search functionality
    /// </summary>
    [Category("UI")]
    internal class SearchTest : Test
    {
        // Tests search results for different keywords
        [Test, TestCaseSource(typeof(Test), nameof(SearchPage))]
        public void TestCase2(string keyword)
        {
            new SearchContext(Driver!)
                .ClickMagnifierIcon()
                .SendKeysSearch(keyword)
                .ClickFindSearch()
                .ScroolToLastLink();

            Log.Information("Search page interactions completed successfully");

            new SearchValidation(Driver!)
                .ValidateAllLinksNotContainOtherKeywords(keyword)
                .ValidateAllLinksContainTheKeywordCloud(keyword)
                .ValidateLastLinkResultsDisplayed();
        }
    }
}
