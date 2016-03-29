using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace SimpleDemoApp.WebDriver
{
    [TestClass]
    public class ChromeTests
    {

        private static RemoteWebDriver _webDriver = null;
        private static string _webAppBaseURL = "http://gdaviwebappdev.azurewebsites.net";

        [ClassInitialize()]
        // All tests in this class are going to use Chrome, therefore set the Chrome driver up once here
        public static void ClassInit(TestContext context)
        {
            // Chrome specifics
            _webDriver = new ChromeDriver(@"C:\Tools");

            //Set page load timeout to 5 seconds 
            _webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
            }
        }

        [TestMethod]
        [TestCategory("UI")]
        public void HomePageFoundChromeTest()
        {
            _webDriver.Url = _webAppBaseURL;

            string actualPageTitle = _webDriver.Title;
            string expectedPageTitle = "Home Page - My ASP.NET Application";

            Assert.AreEqual(actualPageTitle, expectedPageTitle);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void AboutPageFoundChromeTest()
        {
            _webDriver.Url = _webAppBaseURL + "/Home/About";

            string actualPageTitle = _webDriver.Title;
            string expectedPageTitle = "About - My ASP.NET Application";

            Assert.AreEqual(actualPageTitle, expectedPageTitle);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void ContactPageFoundChromeTest()
        {
            _webDriver.Url = _webAppBaseURL + "/Home/Contact";

            string actualPageTitle = _webDriver.Title;
            string expectedPageTitle = "Contact - My ASP.NET Application";

            Assert.AreEqual(actualPageTitle, expectedPageTitle);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void SupportEmailAddressChromeTest()
        {
            string supportEmailAddress = "Support@example.com";

            _webDriver.Url = _webAppBaseURL + "/Home/Contact";
            RemoteWebElement supportEmailElement = (RemoteWebElement)_webDriver.FindElementByLinkText(supportEmailAddress);

            Assert.AreEqual(supportEmailElement.Text, supportEmailAddress);
        }

        [TestMethod]
        [TestCategory("UI")]
        public void MarketingEmailAddressChromeTest()
        {
            string marketingEmailAddress = "Marketing@example.com";

            _webDriver.Url = _webAppBaseURL + "/Home/Contact";
            RemoteWebElement marketingEmailElement = (RemoteWebElement)_webDriver.FindElementByLinkText(marketingEmailAddress);

            Assert.AreEqual(marketingEmailElement.Text, marketingEmailAddress);
        }

    }
}
