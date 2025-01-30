using Business.ApplicationInterface;
using OpenQA.Selenium;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the About page.
    /// This class encapsulates interactions with the <see cref="AboutPage"/> for testing or operational purposes.
    /// </summary>
    public class AboutContext
    {
        // Private field to store an instance of the AboutPage
        private readonly AboutPage _aboutPage;

        // Constructor takes an IWebDriver instance as a parameter, which is used to initialize the AboutPage
        public AboutContext(IWebDriver driver)
        {
            _aboutPage = new AboutPage(driver);
        }

        // Clicks the About link  
        public AboutContext ClickAbout()
        {
            _aboutPage.ClickAbout();
            return this;
        }

        // Scrolls to "Epam At A Glance" section  
        public AboutContext ScrollToEpamAtGlance()
        {
            _aboutPage.ScrollToEpamAtGlance();
            return this;
        }
        
        // Clicks the download button  
        public AboutContext ClickDownload()
        {
            _aboutPage.ClickDownload();
            return this;
        }
    }
}
