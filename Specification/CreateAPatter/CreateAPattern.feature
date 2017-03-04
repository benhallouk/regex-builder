Feature: CreateAPattern
	As a site admin
	I would like to create a new patterns
	So that other users can use it

Scenario: Create a pattern
	Given The following data:
	| Title   | Description   | Template   |
	| title 1 | description 1 | template 1 |
	When I create a pattern
	Then The following data must be recorded:
	| Title   | Description   | Template   |
	| title 1 | description 1 | template 1 |
