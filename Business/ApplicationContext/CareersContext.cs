using Business.ApplicationInterface;
using OpenQA.Selenium;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the Careers page.
    /// This class encapsulates interactions with the <see cref="CareersPage"/> for testing or operational purposes.
    /// </summary>
    public class CareersContext
    {
        // Private field to store an instance of the CareerPage
        private readonly CareersPage _careerPage;

        // Constructor takes an IWebDriver instance as a parameter, which is used to initialize the AboutPage
        public CareersContext(IWebDriver driver)
        {
            _careerPage = new (driver);
        }

        // Navigates to the Careers page  
        public CareersContext ClickCareers()
        {
            _careerPage.ClickCareers();

            return this;
        }

        // Enters a keyword into the search field  
        public CareersContext SendKeysKeyword(string keyword) 
        {
            _careerPage.SendKeysKeyword(keyword);

            return this;
        }

        // Opens the location dropdown  
        public CareersContext ClickLocation()
        {
            _careerPage.ClickLocation();
            
            return this;
        }

        // Selects all locations
        public CareersContext ClickAllLocations()
        {
            _careerPage.ClickAllLocations();

            return this;
        }

        // Checks the remote filter  
        public CareersContext ClickRemote()
        {
            _careerPage.ClickRemote();

            return this;
        }

        // Submits the job search  
        public CareersContext ClickFindCareers()
        {
            _careerPage.ClickFindCareers();

            return this;
        }

        // Opens the latest job result
        public CareersContext ClickViewAndApply()
        {
            _careerPage.ClickViewAndApply();
            
            return this;
        }
    }
}
