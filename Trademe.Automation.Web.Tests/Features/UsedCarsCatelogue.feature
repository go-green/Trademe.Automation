@Web @Catelogue
Feature: Used cars catelogue scenarios
	As a trademe user
	I want to filter and search used vehicles
	So that I can narrow down my search results and easily find the vehicle I need


Scenario: Trademe user views available used vehicle categories
	Given I have navigated to trademe 'motors' category
	And I have opened the advanced search page
	When I select the vehicle make drop down menu 
	Then I am able to see a list of vehicle brands


Scenario: Trademe user filters used vehicles using a given vehicle brand
	Given I have navigated to trademe 'motors' category
	And I have opened the advanced search page
	And I have entered 'Kia' into the keyword field
	And I have left all other filter parameters unchanged
	When I search for vehicles
	Then I am able to see used vehicles according my filter criteria


Scenario: Trademe user attempts to search for a vehicle brand that doesn't exist in the system
	Given I have navigated to trademe 'motors' category
	And I have opened the advanced search page
	When I attempt to select brand 'Hispano Suiza' from the vehicle make drop down menu 
	Then I am unable to see that option available