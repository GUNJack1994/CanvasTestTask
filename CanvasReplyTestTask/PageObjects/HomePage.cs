using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasReplyTestTask.PageObjects
{
    public class HomePage
    {
        private IWebDriver _webDriver;
        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickOnTab(string tabName) 
        {
            var tabXpath = _webDriver.FindElement(By.XPath($"//a[@title='{tabName}']"));
            tabXpath.Click();
        }
    }
}
