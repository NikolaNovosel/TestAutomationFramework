using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Serilog;

namespace Business.ApplicationInterface
{
    /// <summary>
    /// Represents the Search page of the application
    /// This class contains elements and actions related to the Search page
    /// </summary>
    public class SearchPage(IWebDriver driver) : Page(driver)
    {
        // Magnifier Icon in the navigation menu
        private IWebElement Magnifier => Driver.FindElement(By.CssSelector("span.header-search__search-icon"));

        // Parent element for the Search input
        private IWebElement SearchParent => Wait.Until(driver =>
        {
            var element = Driver.FindElement(By.ClassName("header-search__panel"));
            return element.Displayed && element.Enabled? element : null;
        });

        // Search input field
        private IWebElement Search =>  Wait.Until(driver =>
        {
            var element = SearchParent.FindElement(By.Name("q"));
            return element.Displayed && element.Enabled? element : null;
        });

        // Find search button
        private IWebElement FindSearch => Wait.Until(driver => driver.FindElement(By.CssSelector("div.search-results__input-holder+button")));

        // Last link in search results
        private IWebElement ScrolledLastLink => Wait.Until(driver =>
        {
            var element = driver.FindElement(By.XPath("//div[@class='search-results__items']/article[last()]"));
            return element.Displayed ? element : null;
        });

        // Assumed to be the last link element to check for visibility
        IWebElement LastSearchResultLink => Wait.Until(driver => {
            var element = driver.FindElement(By.XPath("//div[@class='search-results__items']/article[20]"));
            return element.Displayed ? element : null;
        });

        // All links in search results
        private IEnumerable<IWebElement> Links => Driver.FindElements(By.XPath("//div[@class='search-results__items']//article/h3/a"));

        // Opens the search bar
        public void ClickMagnifierIcon()
        {
            Log.Information("Opens the search bar");
            Magnifier.Click(); 
        }

        // Enters the search string
        public void SendKeysSearch(string searchString)
        {
            Log.Information("Enters the search string");
            Search.SendKeys(searchString); 
        }

        // Submits the search
        public void ClickFindSearch()
        { 
            Log.Information("Submits the search");
            FindSearch.Click(); 
        }

        // Scroll to the last link
        public void ScroolToLastLink()
        {
            Log.Information("Scroll to the last link");
            Actions.ScrollByAmount(0, ScrolledLastLink.Location.Y).Perform(); 
        }

        // Check if the last 20th link is visible
        public bool HasLastLink() => LastSearchResultLink.Displayed;

        // Checks if all the links containing the keyword
        public bool CheckIfAllLinksContainKeyword(string keyword)
        => Links.All(link => link.Text.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }
}
