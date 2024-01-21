using CanvasReplyTestTask.Hooks;
using OpenQA.Selenium;

namespace CanvasReplyTestTask.PageObjects
{
    public class LoginPage
    {
        private IWebDriver _webDriver;
        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement UserName => _webDriver.FindElement(By.Id("login_user"));

        public IWebElement Password => _webDriver.FindElement(By.Id("login_pass"));

        public IWebElement LoginButton => _webDriver.FindElement(By.XPath("//span[text()='Login']"));

        public void LogToApplication() 
        {
            _webDriver.Url = SharedBrowserHooks.AppConfig.ApplicationUrl;

            UserName.SendKeys(SharedBrowserHooks.AppConfig.Login);
            Password.SendKeys(SharedBrowserHooks.AppConfig.Password);

            LoginButton.Click();
        }
    }
}