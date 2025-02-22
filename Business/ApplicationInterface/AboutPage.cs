using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Serilog;

namespace Business.ApplicationInterface
{
    /// <summary>
    /// Represents the About page of the application
    /// This class contains elements and actions related to the About page
    /// </summary>
    public class AboutPage(IWebDriver driver) : Page(driver)
    {
        // About link in the navigation menu
        private IWebElement About => NavBar.FindElement(By.XPath("./li[4]"));

        // "Epam At A Glance" section  
        private IWebElement EpamAtGlanceDiv => Driver.FindElement(By.XPath("//main[@id='main']/div[1]/div[5]//div[@class='colctrl__holder']")); 

        // Download button in "Epam At A Glance" section  
        private IWebElement DownloadButton =>
        Wait.Until(driver =>
        {
            var element = EpamAtGlanceDiv.FindElement(By.XPath("//div[@class='button']//span[normalize-space(text())='DOWNLOAD']"));
            return element.Enabled ? element : null;
        });

        // Navigates to the About page  
        public void ClickAbout()
        { 
            Log.Information("Navigates to the About page");
            About.Click();
        }

        // Scrolls to "Epam At A Glance" section  
        public void ScrollToEpamAtGlance() 
        {
            Log.Information(@"Scrolls to ""Epam At Glance section""");
            Actions.ScrollByAmount(0, EpamAtGlanceDiv.Location.Y).Perform(); 
        }

        // Clicks the download button  
        public void ClickDownload()
        {
            try
            {
                Log.Information("Try to click the download button");
                DownloadButton.Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Enabled);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Click the download button");
                DownloadButton.Click();

                Log.Information("Error gracefully handled");
            }
        }
    }
}
