Feature: TaxRates

	Tax Rates Feature

Scenario: _01 Create New Tax Profiles
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I click on button Insert on page Tax Profiles
	Then I insert Tax profile with value "EA Test"
	Then I insert Tax profile decription with value "EA Test desc"
	Then I select FSS Status with value "FSS Part Time" 
	Then I click on checbox Tax on annual proj. gross
	Then I click on button Save on page Tax Profiles
	Then I refesh page Tax Profiles
	Then I insert on search Tax profile value "EA Test"
	And I check If Tax profile "EA Test" exist in table


Scenario: _02 Create New Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I insert on search Tax profile value "EA Test"
	And I check If Tax profile "EA Test" exist in table
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

Scenario: _03 Edit Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I insert on search Tax profile value "EA Test"
	And I check If Tax profile "EA Test" exist in table
	Then I click on tab buton Rates
	Then I insert on search Tax rate value "EA 1991"
	Then I click on button Edit on page Tax Rates
	Then I edit "Date from" with values "02/02/2022"
	Then I edit "Date to" with values "02/11/2022"
	Then I edit "Range from" with values "2000"
	Then I edit "Range to" with values "10000"
	Then I edit "Tax rate" with values "12"
	Then I edit "Substract" with values "900"
	Then I click on checbox Show as PT
	Then I click on button Save on page Tax Rate

Scenario: _04 Delete Tax Rate
	Given I open shireburn website
	Then I login to website 
	And I check If website is open
	Then I click on module button Tax Profiles
	Then I insert on search Tax profile value "EA Test"
	And I check If Tax profile "EA Test" exist in table
	Then I click on tab buton Rates
	Then I insert on search Tax rate value "EA 1991"
	Then I select Tax Rate from Grid with index "1"
	Then I click on button Delete on page Tax Rate
	Then I click on button Delete from dialog on page Tax Rate