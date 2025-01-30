using Business.ApplicationInterface;
using OpenQA.Selenium;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the Insights page.
    /// This class encapsulates interactions with the <see cref="InsightsPage"/> for testing or operational purposes.
    /// </summary>
    public class InsightContext
    {
        // Private field to store an instance of the InsightPage
        private readonly InsightsPage _insightsPage;

        // Constructor takes an IWebDriver instance as a parameter, which is used to initialize the InsightPage
        public InsightContext(IWebDriver driver)
        {
            _insightsPage = new (driver);
        }

        // Opens the location dropdown  
        public InsightContext ClickInsight()
        {
            _insightsPage.ClickInsight();
            return this;
        }

        // Swipes the carousel
        public InsightContext SwipeCarousel()
        {
            _insightsPage.SwipeCarousel();
            return this;
        }

        public string GetMainPageArticleTextTrim() => _insightsPage.GetMainPageArticleTextTrim();

        // Clicks the "Read More" button in the carousel
        public InsightContext ClickReadMore()
        {
            _insightsPage.ClickReadMore();
            return this;
        }
    }
}
