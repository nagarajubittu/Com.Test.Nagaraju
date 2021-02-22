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
    public class OrderPage
    {
        private readonly IWebDriver webDriver;

        private readonly WebDriverWait webDriverWait;
        public string OrderId { get; private set; }


        public OrderPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
            webDriverWait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(10));
        }

        [FindsBy(How = How.CssSelector, Using = @".cart_navigation a[title=""Proceed to checkout""]")]
        private IWebElement proceedToCheckout;

        public void ProceedToCheckout()
        {
            proceedToCheckout.Click();
        }

        [FindsBy(How = How.Name, Using = "processAddress")]
        private IWebElement addressProceedToCheckout;

        public void AddressProceedToCheckout()
        {
            addressProceedToCheckout.Click();
        }

        [FindsBy(How = How.CssSelector, Using = ".checkbox #cgv")]
        private IWebElement agreeTC;

        public void AgreeTC()
        {
            agreeTC.Click();
        }

        [FindsBy(How = How.Name, Using = "processCarrier")]
        private IWebElement shippingProceedToCheckout;

        public void ShippingProceedToCheckout()
        {
            shippingProceedToCheckout.Click();
        }

        [FindsBy(How = How.CssSelector, Using = ".payment_module .cheque")]
        private IWebElement paymentSelection;

        public void PaymentSelection()
        {
            paymentSelection.Click();
        }

        [FindsBy(How = How.CssSelector, Using = ".cart_navigation button")]
        private IWebElement confirmOrder;

        public void ConfirmOrder()
        {
            confirmOrder.Click();
        }

        [FindsBy(How = How.CssSelector, Using = "div.order-confirmation")]
        private IWebElement orderConfirmation;

        public void OrderConfirmation()
        {
            var regex = new Regex("[A-Z]{9}");
            var match = regex.Match(orderConfirmation.Text);
            if (match.Success)
            {
                OrderId = match.Value;
            }
        }

        [FindsBy(How = How.CssSelector, Using = ".cart_navigation a")]
        private IWebElement backToOrderHistory;

        public void BackToOrderHistory()
        {
            backToOrderHistory.Click();
        }
    }
}