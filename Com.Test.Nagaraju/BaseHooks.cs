using Com.Test.Nagaraju.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Com.Test.Nagaraju
{
    [Binding]
    public sealed class BaseHooks
    {

        private const string homeUrl = "http://automationpractice.com/index.php";

        [Before]
        public async Task CreateChromeDriver(ScenarioContext context)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            context["WEB_DRIVER"] = webDriver;

            webDriver.Navigate().GoToUrl(homeUrl);
            var cookies = await StoreAuthentication.SignInAsync();
            foreach (var cookie in cookies)
            {
                webDriver.Manage().Cookies.AddCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, cookie.Expires));
            }
            webDriver.Navigate().GoToUrl(homeUrl);
        }

        [After]
        public void CloseChromeDriver(ScenarioContext context)
        {
            IWebDriver webDriver = context["WEB_DRIVER"] as IWebDriver;
            webDriver.Close();
        }
    }
}
