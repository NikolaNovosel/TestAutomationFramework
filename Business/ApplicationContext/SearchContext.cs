using Business.ApplicationInterface;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the Search page.
    /// This class encapsulates interactions with the <see cref="SearchPage"/> for testing or operational purposes.
    /// </summary>
    public class SearchContext(SearchPage searchPage)
    {
        // Opens the search bar
        public SearchContext ClickMagnifierIcon() 
        {
            searchPage.ClickMagnifierIcon();
            return this;
        } 

        // Enters the search string
        public SearchContext SendKeysSearch(string searchString)
        {
            searchPage.SendKeysSearch(searchString);
            return this;
        }

        // Submits the search
        public SearchContext ClickFindSearch()
        {
            searchPage.ClickFindSearch();
            return this;
        }

        // Scroll to the last link
        public SearchContext ScroolToLastLink()
        {
            searchPage.ScroolToLastLink();
            return this;
        }
    }
}
