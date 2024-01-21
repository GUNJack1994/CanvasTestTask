using CanvasReplyTestTask.Drivers;
using CanvasReplyTestTask.PageObjects.ReportAndSettingsPages;

namespace CanvasReplyTestTask.StepDefinitions
{
    [Binding]
    public class ReportAndSettingsStepDefinitions
    {
        private readonly ReportAndSettingsPage _reportAndSettingsPage;
        private readonly ActivityLogPage _activityLogPage;

        private List<string> NamesList = new List<string>();

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
            _activityLogPage.SelectCheckBox(count);
            NamesList = _activityLogPage.GetNames(3);
        }

        [When(@"Delete elements")]
        public void WhenDeleteElements()
        {
            _activityLogPage.DeleteContact();
        }

        [Then(@"Check if those elements were removed")]
        public void ThenCheckIfThoseElementsWereRemoved()
        {
            var NamesAfetDeleted = _activityLogPage.GetNames(3);
            NamesAfetDeleted.Should().NotBeEquivalentTo(NamesList);
        }
    }
}