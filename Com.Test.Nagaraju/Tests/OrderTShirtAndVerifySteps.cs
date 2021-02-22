using Com.Test.Nagaraju.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace Com.Test.Nagaraju.Tests
{
    [Binding]
    public class OrderTShirtAndVerifySteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly OrderPage _orderPage;

        public OrderTShirtAndVerifySteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext["WEB_DRIVER"] as IWebDriver;
            _orderPage = new OrderPage(_webDriver);
        }

        [Given(@"i navigate to home page")]
        public void GivenINavigateToHomePage()
        {
            _webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [Given(@"i click on Tshirts")]
        public void GivenIClickOnTshirts()
        {
            var homePage = new HomePage(_webDriver);
            homePage.TShirtNavigate();
        }

        [When(@"i select one of the T-shirts and i add to cart")]
        public void WhenISelectOneOfTheT_ShirtsAndIAddToCart()
        {
            var tShirtPage = new TshirtsPage(_webDriver);
            tShirtPage.AddToCart();
        }

        [When(@"i click on checkout")]
        public void WhenIClickOnCheckout()
        {
            var tShirtPage = new TshirtsPage(_webDriver);
            tShirtPage.ProceedToCheckout();
        }

        [When(@"i click on proceed to checkout at order summary step")]
        public void WhenIClickOnProceedToCheckoutAtOrderSummaryStep()
        {
            _orderPage.ProceedToCheckout();
        }

        [When(@"click to proceed at address step")]
        public void WhenClickToProceedAtAddressStep()
        {
            _orderPage.AddressProceedToCheckout();
        }

        [When(@"i agree for T&C at shipping step and click to proceed")]
        public void WhenIAgreeForTCAtShippingStepAndClickToProceed()
        {
            _orderPage.AgreeTC();
            _orderPage.ShippingProceedToCheckout();
        }


        [When(@"i click on pay by check")]
        public void WhenIClickOnPayByCheck()
        {
            _orderPage.PaymentSelection();
        }

        [When(@"i navigate to confirm order")]
        public void WhenINavigateToConfirmOrder()
        {
            _orderPage.ConfirmOrder();
        }

        [When(@"my order should be completed successfully")]
        public void WhenMyOrderShouldBeCompletedSuccessfully()
        {
            _orderPage.OrderConfirmation();

        }

        [When(@"i click on back to orders")]
        public void WhenIClickOnBackToOrders()
        {
            _orderPage.BackToOrderHistory();
        }

        [Then(@"i navigate to order history page")]
        public void ThenINavigateToOrderHistoryPage()
        {
            var historyPage = new HistoryPage(_webDriver);
            Assert.EndsWith("history", _webDriver.Url);
        }

        [Then(@"verify order details")]
        public void ThenVerifyOrderDetails()
        {
            var historyPage = new HistoryPage(_webDriver);
            Assert.True(historyPage.IsOrderIdPresent(_orderPage.OrderId));
        }



    }
}
