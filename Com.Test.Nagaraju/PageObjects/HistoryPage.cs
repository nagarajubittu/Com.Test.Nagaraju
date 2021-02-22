using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace Com.Test.Nagaraju.PageObjects
{
    public class HistoryPage
    {
        private readonly IWebDriver webDriver;

        private readonly WebDriverWait webDriverWait;


        public HistoryPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
            webDriverWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(10));
        }

        public bool IsOrderIdPresent(string orderId)
        {
            var element = webDriverWait.Until(drv => drv.FindElement(By.Id("order-list")));
            var tbody = element.FindElement(By.TagName("tbody"));
            var trElements = tbody.FindElements(By.TagName("tr"));
            foreach(var tr in trElements)
            {
                var aEle = tr.FindElement(By.CssSelector("td.history_link a"));
                if (aEle.Text.Trim() == orderId)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
