using OpenQA.Selenium;

namespace CanvasReplyTestTask.PageObjects.SalesAndMarketingPages
{
    public class SalesAndMarketingPage
    {
        private readonly IWebDriver _webDriver;
        public SalesAndMarketingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickOnTab(string tabName)
        {
            var tabXpath = _webDriver.FindElement(By.XPath($"//span[text()='{tabName}']/parent::a"));
            tabXpath.Click();
        }
    }
}