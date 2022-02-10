Feature: TaxProfiles

Tax Profiles test cases

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
