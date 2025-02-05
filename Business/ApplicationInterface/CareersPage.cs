using Core.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Serilog;

namespace Business.ApplicationInterface
{
    /// <summary>
    /// Represents the Careers page of the application
    /// This class contains elements and actions related to the Careers page
    /// </summary>
    public class CareersPage(IWebDriver driver) : Page(driver)
    {
        // Careers link in the navigation menu  
        private IWebElement Careers => NavBar.FindElement(By.XPath("./li[5]"));

        // Keyword input field
        private IWebElement Keywords => Driver.FindElement(By.Id("new_form_job_search-keyword"));

        // Location dropdown
        private IWebElement Location => Wait.Until(driver =>
        {
            var element = Driver.FindElement(By.XPath("//div[@class='recruiting-search__column']//span[@class='select2-selection__arrow']"));
            return element.Displayed && element.Enabled ? element : null;
        });

        // All locations option  
        private IWebElement AllLocations => Driver.FindElement(By.XPath("//li[normalize-space(text())='All Locations']"));

        // Parent element for the Remote Checkbox
        private IWebElement RemoteParent => Driver.FindElement(By.CssSelector("div.job-search__filter-list"));

        // Remote checkbox 
        private IWebElement Remote => RemoteParent.FindElement(By.XPath("//label[normalize-space(text())='Remote']"));

        // Parent element for the Find button
        private IWebElement FindForm => Driver.FindElement(By.Id("jobSearchFilterForm"));

        // Find button
        private IWebElement FindCareers => FindForm.FindElement(By.TagName("button"));

        // Parent element for the View and Apply button
        private IWebElement LatestResult => Wait.Until(driver=>
        {
           var element = Driver.FindElement(By.XPath("//ul[@class='search-result__list']/child::li[1]"));
           return element.Displayed && element.Enabled ? element : null;
        });

        // View and Apply button for the latest job result  
        private IWebElement ViewAndApply => Wait.Until(driver=>
        {
           var element = LatestResult.FindElement(By.LinkText("VIEW AND APPLY"));
           return element.Displayed && element.Enabled ? element : null;
        });

        // Job title text
        private IWebElement CareersArticle => Driver.FindElement(By.ClassName("vacancy-details-23__job-title"));

        // Navigates to the Careers page  
        public void ClickCareers()
        {
            Log.Information("Navigates to the Careers page");
            Careers.Click(); 
        }

        // Enters a keyword into the search field  
        public void SendKeysKeyword(string keyword)
        { 
            Log.Information("Enters a keyword into the search field");
            Keywords.SendKeys(keyword);
        }

        // Opens the location dropdown list
        public void ClickLocation()
        {
            try
            {
                Log.Information("Try to open the location dropdown list");
                Location.Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Enabled);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Open the location dropdown list");
                Location.Click();

                Log.Information("Error gracefully handled");
            }
        }

        // Selects all locations
        public void ClickAllLocations() 
        {
            Log.Information("The location dropdown opened");
            Log.Information("Selects all locations");
            AllLocations.Click(); 
        }

        // Checks the remote filter  
        public void ClickRemote()
        {
            try
            {
                Log.Information("Try to check the remote filter");
                Driver.ExecuteJavaScript("arguments[0].click()", Remote);
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Enabled);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Check the remote filter");
                Remote.Click();

                Log.Information("Error gracefully handled");
            }
        }

        // Submits the job search  
        public void ClickFindCareers() 
        {
            Log.Information("The remote filter checked");
            Log.Information("Submits the job search");
            FindCareers.Click(); 
        }

        // Opens the latest job result
        public void ClickViewAndApply()
        {
            try
            {
                Log.Information("Try to open the latest job result");
                ViewAndApply.Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error($"Error: {ex.Message}");

                Log.Information("Wait for the cookie to be displayed");
                Wait.Until(driver => Cookie.Enabled);

                Log.Information("Execute java script to set cookie display to none");
                Driver.ExecuteJavaScript("document.querySelector('#onetrust-banner-sdk').style.display='none'");

                Log.Information("Open the latest job result");
                ViewAndApply.Click();

                Log.Information("Error gracefully handled");
            }
        }

        // Returns the job title text  
        public string GetCareersArticleText() => CareersArticle.Text;
    }
}
