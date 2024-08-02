Feature: Managing Measurement Dimensions
In order to categorize unit of measures and convert them to each other only in their dimension
As a procurement manager
I want to be able to define measurement dimensions

Scenario: Defining dimension
	Given I have entered as procument manager account
	When I define the following dimension
		| Name | Symbol |
		| Mass | m      |
	Then I should be able to see the dimension in the list of dimensions