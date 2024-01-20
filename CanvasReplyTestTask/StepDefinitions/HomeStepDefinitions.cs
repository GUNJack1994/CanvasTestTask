using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasReplyTestTask.StepDefinitions
{
    [Binding]
    public class HomeStepDefinitions
    {
        private readonly HomePage _homePage;

        public HomeStepDefinitions(Driver driver)
        {
            _homePage = new HomePage(driver.Current);
        }

        [When(@"Click on ""([^""]*)"" tab")]
        public void WhenClickOnTab(string tabName)
        {
            _homePage.ClickOnTab(tabName);
        }

        [When(@"Click on ""([^""]*)"" tab and choose ""([^""]*)"" subtab")]
        public void WhenClickOnTabAndChooseSubtab(string tabName, string subTabName)
        {
            throw new PendingStepException();
        }
    }
}
