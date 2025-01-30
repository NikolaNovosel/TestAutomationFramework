using Core.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using Serilog;

namespace Business.ApplicationInterface
{
    /// <summary>
    /// Represents the Insights page of the application
    /// This class contains elements and actions related to the Insights page
    /// </summary>
    public class InsightsPage(IWebDriver driver) : Page(driver)
    {
        // Insight link in the navigation menu
        private IWebElement Insight => NavBar.FindElement(By.XPath("./li[3]"));

        // Carousel section on the page
        private IWebElement Carousel => Driver.FindElement(By.XPath("//main[@id='main']/div[1]/div[1]//div[@class='owl-stage']"));

        // Parent element of the main page article in the carousel
        private IWebElement MainArticleParent => Carousel.FindElement(By.XPath("./div[6]"));

        // Main page article in the carousel
        private IWebElement MainArticle => MainArticleParent.FindElement(By.CssSelector(".font-size-60:first-child"));

        // "Read More" button in the carousel
        private IWebElement ReadMore => MainArticleParent.FindElement(By.PartialLinkText("Read More"));

        // The inside article
        private IWebElement InsideArticle =>
        Driver.FindElement(By.XPath("//main[@id='main']/div[1]/div[2]//div[@class='column-control']//span[@class='museo-sans-light']"));

        // Navigate to the Insights page 
        public void ClickInsight()
        {
            Log.Information("Navigate to the Insights page");
            Insight.Click(); 
        }

        // Swipes the carousel
        public void SwipeCarousel()
        {
            for (int swipe = 0; swipe < 2; swipe++)
            {
                Log.Information("Swipes the carousel");
                Actions.DragAndDropToOffset(Carousel, -300, 0).Perform();
            }
            try
            {
                Log.Information("Try to wait for the main article to be displayed");
                Wait.Until(driver => MainArticle.Displayed);
            }
            catch (WebDriverTimeoutException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Swipes the carousel");
                Actions.DragAndDropToOffset(Carousel, -300, 0).Perform();

                Log.Information("Error gracefully handled");
            }
        }

        // Clicks the "Read More" button in the carousel
        public void ClickReadMore()
        {
            Log.Information("Main article displayed");
            try
            {
                Log.Information("Try to click the Read More button in the carousel");
                ReadMore.Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Displayed);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Click the Read More button in the carousel");
                ReadMore.Click();

                Log.Information("Error gracefully handled");
            }
        }

        // Returns the trimmed text of the main page article
        public string GetMainPageArticleTextTrim() => MainArticle.Text.Trim();

        // Returns the text of the inside article
        public string GetInsideArticleText() => InsideArticle.Text;
    }
}
