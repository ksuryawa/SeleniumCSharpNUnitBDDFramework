Feature: AmazonSeach_Ele
	Simple calculator for adding two numbers

@regression	
Scenario Outline: Search Multple Products
	Given I am on the Amazon home page
	When I search for <search_term>
	Then I should see <search_term>

	
	Examples: 
	| search_term |
	| iPhone      |
	| iPad        |	
