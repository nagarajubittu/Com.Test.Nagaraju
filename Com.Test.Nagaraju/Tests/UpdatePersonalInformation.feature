Feature: UpdatePersonalInformation
	As a user
	I want to update my personal information

Scenario Outline: Update my personal information
	Given i naviagte to "my-account" page
	When i click on personal information
	And i naviagte to the personal information "identity" page
	And i provide '<FirstName>' and '<Password>' to update my personal info
	And i click on save the updated details
	Then my personal details should be updated

	Examples:
		| FirstName        | Password |
		| Dummy First Name | Raju1522 |

