Feature: ReportsAndSettings

A short summary of the feature

@tag1
Scenario: Run Report
	Given Login into application
	When Click on "Reports & Settings" tab
	And Find "Project Profitability" report
	And Run report
	Then Verify that some results were returned

Scenario: Remove events from activity log
	Given Login into application
	When Click on "Reports & Settings" tab and choose "Activity Log" subtab
	And Check 3 elements
	And Delete elements
	Then Check if those elements were removed