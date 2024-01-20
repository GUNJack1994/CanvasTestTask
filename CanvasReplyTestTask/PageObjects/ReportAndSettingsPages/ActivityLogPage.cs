using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasReplyTestTask.PageObjects.ReportAndSettingsPages
{
    public class ActivityLogPage
    {
        private readonly IWebDriver _webDriver;

        public ActivityLogPage(IWebDriver webDriver) 
        {
            _webDriver = webDriver;
        }
    }
}
