using System;
using Cafetownsend.Tests.UI.DataTransferObjects;
using Cafetownsend.Tests.UI.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Cafetownsend.Tests.UI
{
	[Binding]
	public class EmployeeSteps : IClassFixture<TestFixture>
	{
		private readonly IWebDriver ngDriver;
		private Employee currentEmployee;

		public HomePage HomePage { get; set; }
		public CreateEmployeePage CreateEmployeePage { get; set; }

		public EmployeeSteps(TestFixture fixture)
		{
			ngDriver = fixture.NgDriver;
		}

		[Given(@"I have logged into the system\.")]
		public void GivenIHaveLoggedIntoTheSystem_()
		{
			HomePage = new LoginPage(ngDriver)
				.Login();
			HomePage.VerifyGreetings("Hello Luke", out var exist);
			Assert.True(exist);
		}
		
		[Given(@"An employee does not exist with below details")]
		public void GivenAnEmployeeDoesNotExistWithBelowDetails(Table table)
		{
			var employee = table.CreateInstance<Employee>();
			HomePage.VerifyEmployeeExists(employee, out var employeeExists);
			if (employeeExists)
			{
				HomePage.DeleteEmployees(employee);
				HomePage.VerifyEmployeeExists(employee, out employeeExists);
			}

			Assert.False(employeeExists);

		}

		[Given(@"An employee exist with below details")]
		public void GivenAnEmployeeExistWithBelowDetails(Table table)
		{
			currentEmployee = table.CreateInstance<Employee>();
			HomePage.VerifyEmployeeExists(currentEmployee, out var employeeExists);
			if (!employeeExists)
			{
				HomePage = HomePage.ClickCreateEmployee().CreateEmployee(currentEmployee);
				HomePage.VerifyEmployeeExists(currentEmployee, out employeeExists);
			}

			Assert.True(employeeExists);
		}


		[When(@"I create a new employee record with below details")]
		public void WhenICreateANewEmployeeRecordWithBelowDetails(Table table)
		{
			var employee = table.CreateInstance<Employee>();
			HomePage = HomePage.ClickCreateEmployee().CreateEmployee(employee);
		}

		[When(@"I edit the employee record with below details")]
		public void WhenIEditTheEmployeeRecordWithBelowDetails(Table table)
		{
			var updatedEmployee = table.CreateInstance<Employee>();
			HomePage.EditEmployee(currentEmployee, updatedEmployee);
		}

		[When(@"I delete the employee with below details")]
		public void WhenIDeleteTheEmployeeWithBelowDetails(Table table)
		{
			var employee = table.CreateInstance<Employee>();
			HomePage = HomePage.DeleteEmployees(employee);
		}



		[Then(@"the new employee should be created with below details")]
		public void ThenTheNewEmployeeShouldBeCreatedWithBelowDetails(Table table)
		{
			var employee = table.CreateInstance<Employee>();
			HomePage.VerifyEmployeeExists(employee, out var exist);
			Assert.True(exist);
		}

		[Then(@"the employee should be updated below details")]
		public void ThenTheEmployeeShouldBeUpdatedBelowDetails(Table table)
		{
			var employee = table.CreateInstance<Employee>();
			HomePage.VerifyEmployeeExists(employee, out var exist);
			Assert.True(exist);
		}

		[Then(@"the employee should be deleted with below details")]
		public void ThenTheEmployeeShouldBeDeletedWithBelowDetails(Table table)
		{
			var employee = table.CreateInstance<Employee>();
			HomePage.VerifyEmployeeExists(employee, out var employeeExists);
			Assert.False(employeeExists);
		}
	}
}
