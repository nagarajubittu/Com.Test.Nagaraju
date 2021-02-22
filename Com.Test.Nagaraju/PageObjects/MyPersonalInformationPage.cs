using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Test.Nagaraju.PageObjects
{
    public class MyPersonalInformationPage
    {
        private readonly IWebDriver webDriver;

        public MyPersonalInformationPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement firstName;

        public void SetFirstName(string firstName)
        {
            this.firstName.Clear();
            this.firstName.SendKeys(firstName);
        }

        [FindsBy(How = How.Id, Using = "old_passwd")]
        private IWebElement oldPassword;

        public void SetOldPassword(string oldPassword)
        {
            this.oldPassword.SendKeys(oldPassword);
        }

        [FindsBy(How = How.Name, Using = "submitIdentity")]
        private IWebElement saveButton;

        public void Save(string firstName, string oldPassword)
        {
            SetFirstName(firstName);
            SetOldPassword(oldPassword);
            saveButton.Click();
        }
        public void Save()
        {
            saveButton.Click();
        }

        [FindsBy(How = How.ClassName, Using = "alert-success")]
        private IWebElement alert;

        public bool IsAlertPresent(string value)
        {
            return alert.Text.Contains(value);
        }




    }
}
