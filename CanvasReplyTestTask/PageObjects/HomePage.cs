using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasReplyTestTask.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _webDriver;
        private readonly Actions _action;
        private readonly WebDriverWait _wait;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _action = new Actions(_webDriver);
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }

        Dictionary<string, string> TabsName = new Dictionary<string, string>() 
        {
            {"Today's Activities", "#grouptab-0" },
            {"Sales & Marketing", "#grouptab-1" },
            {"Order Management", "#grouptab-2" },
            {"Project Management", "#grouptab-3" },
            {"Customer Service", "#grouptab-4" },
            {"Reports & Settings", "#grouptab-5" },
        };

        public IWebElement TabName(string tabName) 
        {
            var correctTab = TabsName.Where(x => x.Key.Contains(tabName))
                .Select(x => x.Value).FirstOrDefault();
            
            return _webDriver.FindElement(
                By.CssSelector($"{correctTab}"));
        } 

        public void ClickOnTab(string tabName) => TabName(tabName).Click();

        public IWebElement SubTabName(string subTabName) => _webDriver.FindElement(
            By.XPath($"//a[@class='menu-tab-sub-list' and normalize-space()='{subTabName}']"));

        public void ClickOnSubTab(string tabName, string subTabName) 
        {
            _action.MoveToElement(TabName(tabName)).Perform();

            _wait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SubTabName(subTabName)));
            _action.MoveToElement(SubTabName(subTabName)).Click().Perform();
        }
    }
}
