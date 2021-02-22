using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Test.Nagaraju.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver webDriver;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }


        [FindsBy(How = How.CssSelector, Using = "nav .login")]
        private IWebElement signIn;

        public void SignIn()
        {
            signIn.Click();
        }

        [FindsBy(How = How.CssSelector, Using = "nav .account")]
        private IWebElement accountNavigation;

        public void AccountNavigation()
        {
            accountNavigation.Click();
        }


        [FindsBy(How = How.CssSelector, Using = ".sf-menu > li:last-child a[title=T-shirts]")]
        private IWebElement tShirtNavigate;

        public void TShirtNavigate()
        {
            tShirtNavigate.Click();
        }
    }
}
