using Business.ApplicationInterface;

namespace Business.ApplicationContext
{
    /// <summary>
    /// Provides context and functionality related to the Careers page.
    /// This class encapsulates interactions with the <see cref="CareersPage"/> for testing or operational purposes.
    /// </summary>
    public class CareersContext(CareersPage careersPage)
    {
        // Navigates to the Careers page  
        public CareersContext ClickCareers()
        {
            careersPage.ClickCareers();

            return this;
        }

        // Enters a keyword into the search field  
        public CareersContext SendKeysKeyword(string keyword) 
        {
            careersPage.SendKeysKeyword(keyword);

            return this;
        }

        // Opens the location dropdown  
        public CareersContext ClickLocation()
        {
            careersPage.ClickLocation();
            
            return this;
        }

        // Selects all locations
        public CareersContext ClickAllLocations()
        {
            careersPage.ClickAllLocations();

            return this;
        }

        // Checks the remote filter  
        public CareersContext ClickRemote()
        {
            careersPage.ClickRemote();

            return this;
        }

        // Submits the job search  
        public CareersContext ClickFindCareers()
        {
            careersPage.ClickFindCareers();

            return this;
        }

        // Opens the latest job result
        public CareersContext ClickViewAndApply()
        {
            careersPage.ClickViewAndApply();
            
            return this;
        }
    }
}
