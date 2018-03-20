using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafetownsend.Tests.UI.DataTransferObjects;
using Cafetownsend.Tests.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Protractor;
using SeleniumExtras.PageObjects;
using Xunit;

namespace Cafetownsend.Tests.UI.PageObjects
{
	public class HomePage: PageBase
	{
		private readonly IWebDriver _driver;

		public HomePage(IWebDriver driver):base(driver)
		{
			this._driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "bAdd")]
		public IWebElement CreateEmployeeButton { get; set; }

		[FindsBy(How = How.Id, Using = "bEdit")]
		public IWebElement EditEmployeeButton { get; set; }

		[FindsBy(How = How.Id, Using = "bDelete")]
		public IWebElement DeleteEmployeeButton { get; set; }

		[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByRepeater), Using = "employee in employees")]
		public IList<IWebElement> Employees { get; set; }

		[FindsBy(How = How.Id, Using = "greetings")]
		public IWebElement Greetings { get; set; }

		public CreateEmployeePage ClickCreateEmployee()
		{
			CreateEmployeeButton.Click();
			return new CreateEmployeePage(_driver);
		}

		public HomePage VerifyGreetings(string greeting, out bool exists)
		{
			exists = Greetings.Text.Equals(greeting);
			return this;
		}

		public HomePage VerifyEmployeeExists(Employee employee, out bool exist)
		{
			exist = false;
			var employees = Employees.Where(item => item.Text.Equals(employee.FirstName+" "+ employee.LastName));
			if (employees.Any())
			{
				foreach (var emp in employees)
				{
					var editEmployeePage = SelectEmployee(emp);
					exist = editEmployeePage.VerifyEmployeeDetails(employee);
					editEmployeePage.BackButton.Click();
					if(exist)
						break;
				}
			}
			return this;
		}

		public EditEmployeePage SelectEmployee(IWebElement emp)
		{
			new Actions(_driver).DoubleClick(emp).Build().Perform();
			return new EditEmployeePage(_driver);
		}

		public HomePage EditEmployee(Employee currentEmployee, Employee updatedEmployee)
		{
			var recordsToBeUpdated = Employees.Where(emp => emp.Text == currentEmployee.FirstName + " " + currentEmployee.LastName);
			while (recordsToBeUpdated.Any())
			{
				var editEmployeePage = SelectEmployee(recordsToBeUpdated.FirstOrDefault());
				editEmployeePage.EditEmployee(currentEmployee, updatedEmployee);
				recordsToBeUpdated = Employees.Where(emp => emp.Text == currentEmployee.FirstName + " " + currentEmployee.LastName);
			}
			return this;
		}
		public HomePage DeleteEmployees(Employee employee)
		{
			var recordsToBeDeleted = Employees.Where(emp => emp.Text == employee.FirstName + " " + employee.LastName);

			while (recordsToBeDeleted.Any())
			{
				var editEmployeePage = SelectEmployee(recordsToBeDeleted.FirstOrDefault());
				editEmployeePage.DeleteEmployee(employee);
				recordsToBeDeleted = Employees.Where(emp => emp.Text == employee.FirstName + " " + employee.LastName);
			}
			return this;
		}
	}
}
