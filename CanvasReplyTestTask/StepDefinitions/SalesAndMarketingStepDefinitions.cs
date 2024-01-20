using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.Hooks;
using CanvasReplyTestTask.PageObjects.SalesAndMarketingPages;

namespace CanvasReplyTestTask.StepDefinitions
{
    [Binding]
    public class SalesAndMarketingStepDefinitions
    {
        private readonly SalesAndMarketingPage _salesAndMarketingPage;
        private readonly CreateContactPage _createContactPage;
        public SalesAndMarketingStepDefinitions(Driver driver)
        {
            _salesAndMarketingPage = new SalesAndMarketingPage(driver.Current);
            _createContactPage = new CreateContactPage(driver.Current);
        }

        [When(@"Click on ""([^""]*)"" button")]
        public void WhenClickOnButton(string tabName)
        {
            _salesAndMarketingPage.ClickOnTab(tabName);
        }

        [When(@"Create new contact")]
        public void WhenCreateNewContact()
        {
            _createContactPage.CreateContact();
        }

        [Then(@"Check if created contact has correct values")]
        public void ThenCheckIfCreatedContactHasCorrectValues()
        {
            _createContactPage.GetDataFromContact();
            _createContactPage.FirstNameAfterCreate.Should().Be(SharedBrowserHooks.AppConfig.TestFirstName);
            _createContactPage.LastNameAfterCreate.Should().Be(SharedBrowserHooks.AppConfig.TestLastName);
            _createContactPage.FirstCategoryAfterCreate.Should().Be(SharedBrowserHooks.AppConfig.FirstCategory);
            _createContactPage.SecondCategoryAfterCreate.Should().Be(SharedBrowserHooks.AppConfig.SecondCategory);
            _createContactPage.BusinessRoleAfterCreate.Should().Be(SharedBrowserHooks.AppConfig.Role);

            _createContactPage.DeleteContact();
        }
    }
}
