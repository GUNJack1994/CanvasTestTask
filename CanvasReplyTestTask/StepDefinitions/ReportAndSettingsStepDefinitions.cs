using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.PageObjects.ReportAndSettingsPages;

namespace CanvasReplyTestTask.StepDefinitions
{
    [Binding]
    public class ReportAndSettingsStepDefinitions
    {
        private readonly ReportAndSettingsPage _reportAndSettingsPage;
        private readonly ActivityLogPage _activityLogPage;
        public ReportAndSettingsStepDefinitions(Driver driver)
        {
            _reportAndSettingsPage = new ReportAndSettingsPage(driver.Current);
            _activityLogPage = new ActivityLogPage(driver.Current);
        }

        [When(@"Find ""([^""]*)"" report")]
        public void WhenFindReport(string projectName)
        {
            _reportAndSettingsPage.FindProject(projectName);
        }

        [When(@"Run report")]
        public void WhenRunReport()
        {
            _reportAndSettingsPage.RunReport();
            _reportAndSettingsPage.ClickOnFirstRadioButton();
        }

        [Then(@"Verify that some results were returned")]
        public void ThenVerifyThatSomeResultsWereReturned()
        {
            _reportAndSettingsPage.CheckIfElemetnsIsNotNull().Should().BeNull();
            _reportAndSettingsPage.ElemetnsCounter.Text.Should().Be(_reportAndSettingsPage.CountElements().Count.ToString());
        }

        [When(@"Check (.*) elements")]
        public void WhenCheckElements(int count)
        {
            throw new PendingStepException();
        }

        [When(@"Delete elements")]
        public void WhenDeleteElements()
        {
            throw new PendingStepException();
        }

        [Then(@"Check if those elements were removed")]
        public void ThenCheckIfThoseElementsWereRemoved()
        {
            throw new PendingStepException();
        }
    }
}
