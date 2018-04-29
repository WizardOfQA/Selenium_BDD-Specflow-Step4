Feature: test
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: Pre-condition
	#Given Step
	Given I am at the Home page
@Demo
Scenario: sf_User_Can_Search_Vacation_Rental	
	When I navigate to Vacation Rental
	Then I am at the Vacation Rental page
	When I Provide "Central Park, New York, New York",  "09/19/2018", "09/23/2018", "2" and Click on Search button
	Then Result page is displayed with "Central Park Hotel Search Results | Orbitz"
@Demo
Scenario: sf_User_Can_Search_Rental_Car_With_Advanced_Options
	When I navigate to Cars page
	Then I am at the Car page
	When I provide "LAX", "07/06/2018", "28", "07/09/2018", "12" and Click on Advanced options
	Then Car type label is shown
	When I check on Infant seat, Toddler seat, Navigation system options 
	And  Click on Search button
	Then Result page is displayed with "Rental Cars and Car Rentals at Los Angeles Airport from Orbitz"
