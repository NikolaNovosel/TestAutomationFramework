using Business.ApplicationInterface;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the About page.
    /// This class encapsulates interactions with the <see cref="AboutPage"/> for testing or operational purposes.
    /// </summary>
    public class AboutContext(AboutPage aboutPage)
    {
        // Clicks the About link  
        public AboutContext ClickAbout()
        {
            aboutPage.ClickAbout();
            return this;
        }

        // Scrolls to "Epam At A Glance" section  
        public AboutContext ScrollToEpamAtGlance()
        {
            aboutPage.ScrollToEpamAtGlance();
            return this;
        }
        
        // Clicks the download button  
        public AboutContext ClickDownload()
        {
            aboutPage.ClickDownload();
            return this;
        }
    }
}
