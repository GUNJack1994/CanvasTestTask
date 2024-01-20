using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasReplyTestTask.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions(Driver driver) 
        {
            _loginPage = new LoginPage(driver.Current);
        }

        [Given(@"Login into application")]
        public void GivenLoginIntoApplication()
        {
            _loginPage.LogToApplication();
        }
    }
}
