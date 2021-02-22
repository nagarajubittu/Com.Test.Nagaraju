using Com.Test.Nagaraju.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

namespace Com.Test.Nagaraju.Tests
{
    [Binding]
    public class UpdatePersonalInformationSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;

        public UpdatePersonalInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"i naviagte to ""(.*)"" page")]
        public void GivenINaviagteToPage(string accountUrl)
        {
            var homePage = new HomePage(_webDriver);
            homePage.AccountNavigation();
            Assert.EndsWith(accountUrl, _webDriver.Url);
        }

        [When(@"i click on personal information")]
        public void WhenIClickOnPersonalInformation()
        {
            var myAccountPage = new MyAccountPage(_webDriver);
            myAccountPage.MyPersonalInformation();
        }

        [When(@"i naviagte to the personal information ""(.*)"" page")]
        public void WhenINaviagteToThePersonalInformationPage(string personalInfoUrl)
        {
            Assert.EndsWith(personalInfoUrl, _webDriver.Url);
        }

        [When(@"i provide '(.*)' and '(.*)' to update my personal info")]
        public void WhenIProvideAndToUpdateMyPersonalInfo(string firstName, string password)
        {
            var myAccountPage = new MyPersonalInformationPage(_webDriver);
            myAccountPage.SetFirstName(firstName);
            myAccountPage.SetOldPassword(password);
        }

        [When(@"i click on save the updated details")]
        public void WhenIClickOnSaveTheUpdatedDetails()
        {
            var myAccountPage = new MyPersonalInformationPage(_webDriver);
            myAccountPage.Save();

        }

        [Then(@"my personal details should be updated")]
        public void ThenMyPersonalDetailsShouldBeUpdated()
        {
            var myAccountPage = new MyPersonalInformationPage(_webDriver);
            Assert.True(myAccountPage.IsAlertPresent("successfully updated"));
        }
    }
}
