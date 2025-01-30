using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Business.ApplicationInterface
{
    /// <summary>
    /// Base class for page objects. Initializes shared WebDriver components:
    /// - <see cref="IWebDriver"/> for browser interaction
    /// - <see cref="WebDriverWait"/> for synchronization
    /// - <see cref="Actions"/> for advanced user interactions
    /// </summary>
    public class Page
    {
        // Stores the WebDriver instance
        private readonly IWebDriver _driver;

        // Provides explicit waits for elements
        private readonly WebDriverWait _wait;

        // Provides actions for interacting with elements
        private readonly Actions _actions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class
        /// </summary>
        /// <param name="driver">The WebDriver instance to use.</param>
        protected Page(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _actions = new Actions(driver);
        }

        // Provides access to the WebDriver instance  
        protected IWebDriver Driver => _driver;

        // Provides access to the WebDriverWait instance for synchronization  
        protected WebDriverWait Wait => _wait;

        // Provides access to the Actions instance for advanced user interactions  
        protected Actions Actions => _actions;

        // Provides the navbar element on the main page
        protected IWebElement NavBar => _driver.FindElement(By.CssSelector("ul.top-navigation__row"));

        // Provides the cookie banner element
        protected IWebElement Cookie => _driver.FindElement(By.CssSelector("#onetrust-banner-sdk"));
    }
}
