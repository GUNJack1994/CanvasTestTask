using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CanvasReplyTestTask.PageObjects.ReportAndSettingsPages
{
    public class ActivityLogPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _wait;

        public ActivityLogPage(IWebDriver webDriver) 
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }

        public IList<IWebElement> LogsCheckBoxes => _webDriver.FindElements(
            By.XPath("//table[contains(@id, 'listView')]/tbody/tr/td/div/input"));

        public IWebElement ActionButton => _webDriver.FindElement(By.XPath("//button[contains(@id, 'Action')]"));

        public IWebElement DeleteButton => _webDriver.FindElement(By.XPath("//div[contains(text(),'Delete')]"));

        public IList<IWebElement> NamesTable => _webDriver.FindElements(
            By.XPath("//table[contains(@id, 'listView')]/tbody/tr/td/span[1]/a"));

        public void SelectCheckBox(int count) 
        {
            var counter = 0;

            foreach (var i in LogsCheckBoxes) 
            {         
                if (counter < count) 
                {
                    Thread.Sleep(2000);
                    i.Click();
                    counter++;
                }
            }
        }

        public List<string> GetNames(int count) 
        {
            var listOfNames = new List<string>();
            var counter = 0;

            foreach (var i in NamesTable)
            {
                
                if (counter < count)
                {
                    listOfNames.Add(i.Text);
                    counter++;
                }
            }

            return listOfNames;
        }

        public void DeleteContact()
        {
            _wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ActionButton)).Click();

            Thread.Sleep(1000);
            _wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DeleteButton)).Click();

            _webDriver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }
    }
}