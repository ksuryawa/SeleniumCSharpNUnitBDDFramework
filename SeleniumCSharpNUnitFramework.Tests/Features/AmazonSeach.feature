Feature: AmazonSeach
	Simple calculator for adding two numbers

@msmoke
Scenario: Search Amazon
	Given I am on the Amazon home page
	When I search for iPhone
	Then I should see iPhone