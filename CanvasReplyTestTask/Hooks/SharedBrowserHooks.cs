using BoDi;
using CanvasReplyTestTask.Drivers;

namespace CanvasReplyTestTask.Hooks
{
    [Binding]
    public class SharedBrowserHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            //Initialize a shared BrowserDriver in the global container
            testThreadContainer.BaseContainer.Resolve<Driver>();
        }
    }
}
