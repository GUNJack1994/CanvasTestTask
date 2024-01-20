using BoDi;
using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.Support;
using OpenQA.Selenium;

namespace CanvasReplyTestTask.Hooks
{
    [Binding]
    public class SharedBrowserHooks
    {

        public static AppConfig AppConfig;

        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            var configReader = new AppConfigReader();
            AppConfig = configReader.ReadConfig();

            //Initialize a shared BrowserDriver in the global container
            testThreadContainer.BaseContainer.Resolve<Driver>();
        }
    }
}
