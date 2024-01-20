using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CanvasReplyTestTask.PageObjects.ReportAndSettingsPages
{
    public class ReportAndSettingsPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _wait;
        public ReportAndSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }

        public IWebElement SearchReportField => _webDriver.FindElement(By.Id("filter_text"));

        public IWebElement ProjectsName => _webDriver.FindElement(By.XPath("//a[text()='Project Profitability']"));

        public IWebElement RunReportButton => _webDriver.FindElement(By.Name("FilterForm_applyButton"));

        public By ResultTable => By.XPath("//div[contains(@id, 'listView') and contains(@id, 'body')]");

        public IWebElement NoResultElement => _webDriver.FindElement(By.XPath("//div[text()='No results']"));

        public IWebElement ElementsCheckbox => _webDriver.FindElement(By.ClassName("checkbox"));

        public IWebElement ElemetnsCounter => _webDriver.FindElement(
            By.XPath("//span[contains(@id, 'listView') and contains(@id, 'SelectCountHead')]"));

        public void ClickOnFirstRadioButton() => ElementsCheckbox.Click();

        public IList<IWebElement> CountElements() => _webDriver.FindElements(
            By.XPath("//table[contains(@id, 'listView') and contains(@id, 'main')]/tbody/tr"));

        public void FindProject(string projectName)
        {
            SearchReportField.SendKeys(projectName);
            Thread.Sleep(2000);
            SearchReportField.SendKeys(Keys.Enter);
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ProjectsName)).Click();
        }

        public void RunReport()
        {
            Thread.Sleep(2000);
            _wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(RunReportButton)).Click();

            _wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ResultTable));
        }

        public string CheckIfElemetnsIsNotNull()
        {
            try
            {
                return NoResultElement.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
    }
}
