using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Test.Nagaraju.PageObjects
{
    public class MyAccountPage
    {
        private readonly IWebDriver webDriver;

        public MyAccountPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }


        [FindsBy(How = How.CssSelector, Using = ".myaccount-link-list a[title=Orders]")]
        private IWebElement orderHistoryAndDetails;

        public void OrderHistoryAndDetails()
        {

            orderHistoryAndDetails.Click();
        }

        [FindsBy(How = How.CssSelector, Using = ".myaccount-link-list a[title=Information]")]
        private IWebElement myPersonalInformation;

        public void MyPersonalInformation()
        {

            myPersonalInformation.Click();
        }
    }
}
