Feature: Employee 
	In order to maintain employee records
	As a user
	I want create,modify and delete employees.


Scenario: Create a new employee. 
	Given I have logged into the system.
	And An employee does not exist with below details
	| First Name | Last Name | Start Date | Email           |
	| Create     | Test      | 2018-02-09 | create@test.com |
	When I create a new employee record with below details
	| First Name | Last Name | Start Date | Email           |
	| Create     | Test      | 2018-02-09 | create@test.com |
	Then the new employee should be created with below details
	| First Name | Last Name | Start Date | Email           |
	| Create     | Test      | 2018-02-09 | create@test.com |

Scenario: Edit an employee. 
	Given I have logged into the system.
	And An employee exist with below details
	| First Name | Last Name | Start Date | Email         |
	| Edit       | Test      | 2018-02-09 | Edit@test.com |  
	When I edit the employee record with below details
	| First Name | Last Name | Start Date | Email         |
	| Test       | Edit      | 2018-02-09 | test@edit.com |
	Then the employee should be updated below details
	| First Name | Last Name | Start Date | Email         |
	| Test       | Edit      | 2018-02-09 | test@edit.com |



Scenario: Delete an employee. 
	Given I have logged into the system.
	And An employee exist with below details
	| First Name | Last Name | Start Date | Email           |
	| Delete     | Test      | 2018-02-09 | delete@test.com |
	When I delete the employee with below details
	| First Name | Last Name | Start Date | Email           |
	| Delete     | Test      | 2018-02-09 | delete@test.com |
	Then the employee should be deleted with below details
	| First Name | Last Name | Start Date | Email           |
	| Delete     | Test      | 2018-02-09 | delete@test.com |

