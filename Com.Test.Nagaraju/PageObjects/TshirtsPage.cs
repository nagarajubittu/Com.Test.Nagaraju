using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Test.Nagaraju.PageObjects
{
    public class TshirtsPage
    {
        private readonly IWebDriver webDriver;

        private readonly WebDriverWait webDriverWait;

        public TshirtsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
            webDriverWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(15));
        }

        [FindsBy(How = How.CssSelector, Using = @".product_list > li:nth-child(1) a[title=""Add to cart""]")]
        private IWebElement addToCart;

        public void AddToCart()
        {
            var actions = new Actions(webDriver);
            var element = webDriverWait.Until(drv => drv.FindElement(By.CssSelector(@".product_list > li:nth-child(1) a[title=""Add to cart""]")));
            actions.MoveToElement(webDriver.FindElement(By.CssSelector(".product_list > li:nth-child(1)"))).Perform();
            element.Click();
        }

        public void ProceedToCheckout()
        {
            var element = webDriverWait.Until(drv =>
            {
                var ele = drv.FindElement(By.CssSelector("#layer_cart .layer_cart_cart .button-container a"));
                if (ele != null && ele.Displayed && ele.Enabled)
                {
                    return ele;
                } else
                {
                    return null;
                }
            });
            element.Click();
        }
    }
}
