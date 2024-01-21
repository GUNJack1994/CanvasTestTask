using BoDi;
using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.PageObjects;
using CanvasReplyTestTask.Support;

namespace CanvasReplyTestTask.Hooks
{
    [Binding]
    public class SharedBrowserHooks
    {
        public static AppConfig AppConfig;
        public LoginPage _loginPage;
        public HomePage _homePage;

        public SharedBrowserHooks(Driver driver) 
        {
            _loginPage = new LoginPage(driver.Current);
            _homePage = new HomePage(driver.Current);
        }

        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            var configReader = new AppConfigReader();
            AppConfig = configReader.ReadConfig();

            testThreadContainer.BaseContainer.Resolve<Driver>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _homePage.DropDownMenu.Click();
            _homePage.LogOutButton.Click();
        }
    }
}