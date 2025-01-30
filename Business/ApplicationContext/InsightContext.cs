using Business.ApplicationInterface;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the Insights page.
    /// This class encapsulates interactions with the <see cref="InsightsPage"/> for testing or operational purposes.
    /// </summary>
    public class InsightContext(InsightsPage insightPage)
    {
        // Opens the location dropdown  
        public InsightContext ClickInsight()
        {
            insightPage.ClickInsight();
            return this;
        }

        // Swipes the carousel
        public InsightContext SwipeCarousel()
        {
            insightPage.SwipeCarousel();
            return this;
        }

        public string GetMainPageArticleTextTrim() => insightPage.GetMainPageArticleTextTrim();

        // Clicks the "Read More" button in the carousel
        public InsightContext ClickReadMore()
        {
            insightPage.ClickReadMore();
            return this;
        }
    }
}
