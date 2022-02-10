Feature: TaxRates

Tax Rates Scenario

Scenario: _01 Create New Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I insert on search Tax profile value "EA Test"
	Then I click on tab buton Rates
	Then I click on button Insert on page Tax Rates
	Then I insert "Code" with values "EA 1991"
	Then I insert "Date from" with values "01/01/2022"
	Then I insert "Date to" with values "31/12/2022"
	Then I insert "Range from" with values "5000"
	Then I insert "Range to" with values "15000"
	Then I insert "Tax rate" with values "15"
	Then I insert "Substract" with values "1200"
	Then I click on checbox Show as PT
	Then I click on button Save on page Tax Rate

Scenario: _02 Edit Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I insert on search Tax profile value "EA Test"
	Then I click on tab buton Rates
	Then I insert on search Tax rate value "EA 1991"
	Then I click on button Edit on page Tax Rates
	Then I edit "Date from" with values "01/01/2022"
	Then I edit "Date to" with values "31/12/2022"
	Then I edit "Range from" with values "5000"
	Then I edit "Range to" with values "15000"
	Then I edit "Tax rate" with values "15"
	Then I edit "Substract" with values "1200"
	Then I click on checbox Show as PT
	Then I click on button Save on page Tax Rate

Scenario: _03 Delete Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I insert on search Tax profile value "EA Test"
	Then I click on tab buton Rates
	Then I insert on search Tax rate value "EA 1991"
	Then I select Tax Rate from Grid with index "1"
	Then I click on button Delete on page Tax Rate
	Then I click on button Delete from dialog on page Tax Rate