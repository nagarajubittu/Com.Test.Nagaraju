using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Test.Nagaraju.PageObjects
{
    public class SignInPage
    {
        private readonly IWebDriver webDriver;

        public SignInPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement email;

        public void SetEmail(string email)
        {
            this.email.SendKeys(email);
        }

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement password;

        public void SetPassword(string password)
        {
            this.password.SendKeys(password);
        }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement signIn;

        public void SignIn(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            signIn.Click();
        }
    }
}
