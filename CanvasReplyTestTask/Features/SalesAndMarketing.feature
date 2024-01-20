Feature: SalesAndMarketing

Scenario: Create contact
	Given Login into application
	When Click on "Sales & Marketing" tab
	And Click on "Create Contact" button
	And Create new contact
	Then Check if created contact has correct values