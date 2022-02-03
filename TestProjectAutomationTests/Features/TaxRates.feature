Feature: TaxRates

Tax Rates Scenario

Scenario: _01 Create New Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I click on tab buton Rates
	Then I click on button Insert on page Tax Rates
	Then  I insert Code with values "EA 1991"
	Then I insert Date from with value "01/01/2022"
	Then I insert Date to with value "31/12/2022"
	Then I insert Range from with value "5000"
	Then I insert Range to with value "15000"
	Then I insert Tax rate to with value "15"
	Then I insert Substract to with value "1200"
	Then I click on checbox Show as PT
	Then I click on button Save on page Tax Rate

Scenario: _02 Edit Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I click on tab buton Rates
	Then I click on button Edit on page Tax Rates
	Then I edit Date from with value "02/02/2022"
	Then I edit Date to with value "30/11/2022"
	Then I edit Range from with value "3000"
	Then I edit Range to with value "10000"
	Then I edit Tax rate to with value "10"
	Then I edit Substract to with value "900"
	Then I click on checbox Show as PT
	Then I click on button Save on page Tax Rate

Scenario: _03 Delete Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I click on tab buton Rates
	Then I select Tax Rate from Grid with index "1"
	Then I click on button Delete on page Tax Rate
	Then I click on button Delete from dialog on page Tax Rate