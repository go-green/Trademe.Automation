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
	And I have selected 'Kia' from the vehicle make drop down menu 
	And I have left all other filter parameters unchanged
	When I search for vehicles
	Then I am able to see used vehicles according my filter criteria


Scenario: Trademe user attempts to search for a vehicle brand that doesn't exist in the system
	Given I have navigated to trademe 'motors' category
	And I have opened the advanced search page
	When I attempt to select brand 'Hispano Suiza' from the vehicle make drop down menu 
	Then I am unable to see that option available


	# Improvements that I could have made should the time permits
	## Web UI tests doesn't have a Logger implemented(I have done it only for the Api tests).
	## Can implement a HTML report generating capability after a test run to see the pass/fail status and stats
	## Screen shots can be captured before and after every step and embed in the HTML report.
	## Use of IWebDriver in page objects and page components tightly couple the framework to selenium/webdriver. 
	##	 This can be eliminated by wrapping the IWebDriver to a framework specific interface so that the framework will be agnostic of the underlying
	##	 webdriver technology and plugged to a different api later on without changing the test code.
	## WebDriverFactory can be improved to run the tests using any other browser or even on mobiles using appium and RemoteWebDriver
	## Can add more hooks (Before after features / Before after steps) to gather vital information such as time taken to execute each steps to identify bottle necks 
	## Page objects and components only contain the elements that are required to achieve the work flows in scenarios.