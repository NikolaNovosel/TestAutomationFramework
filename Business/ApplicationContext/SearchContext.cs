using Business.ApplicationInterface;
using OpenQA.Selenium;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the Search page.
    /// This class encapsulates interactions with the <see cref="SearchPage"/> for testing or operational purposes.
    /// </summary>
    public class SearchContext
    {
        // Private field to store an instance of the SearchPage
        private readonly SearchPage _searchPage;

        // Constructor takes an IWebDriver instance as a parameter, which is used to initialize the SearchPage
        public SearchContext(IWebDriver driver)
        {
            _searchPage = new (driver);
        }

        // Opens the search bar
        public SearchContext ClickMagnifierIcon() 
        {
            _searchPage.ClickMagnifierIcon();
            return this;
        } 

        // Enters the search string
        public SearchContext SendKeysSearch(string searchString)
        {
            _searchPage.SendKeysSearch(searchString);
            return this;
        }

        // Submits the search
        public SearchContext ClickFindSearch()
        {
            _searchPage.ClickFindSearch();
            return this;
        }

        // Scroll to the last link
        public SearchContext ScroolToLastLink()
        {
            _searchPage.ScroolToLastLink();
            return this;
        }
    }
}
