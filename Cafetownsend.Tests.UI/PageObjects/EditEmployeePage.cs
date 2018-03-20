using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafetownsend.Tests.UI.DataTransferObjects;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;

namespace Cafetownsend.Tests.UI.PageObjects
{
	public class EditEmployeePage: PageBase
	{
		private IWebDriver _driver;

		public EditEmployeePage(IWebDriver driver):base(driver)
		{
			this._driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.firstName")]
		public IWebElement FirstName { get; set; }

		[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.lastName")]
		public IWebElement LastName { get; set; }
		[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.startDate")]
		public IWebElement StartDate { get; set; }
		[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "selectedEmployee.email")]
		public IWebElement Email { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#sub-nav > li > a")]
		public IWebElement BackButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "body > div.main-view.ng-scope.main-view-edit > div > div > form > fieldset > div > button:nth-child(1)")]
		public IWebElement UpdateButton { get; set; }

		[FindsBy(How = How.XPath, Using = "/html/body/div/div/div/form/fieldset/div/p")]
		public IWebElement DeleteButton { get; set; }

		public HomePage EditEmployee(Employee currentEmployee, Employee updatedEmployee)
		{
			if (VerifyEmployeeDetails(currentEmployee))
			{
				FirstName.Clear();
				FirstName.SendKeys(updatedEmployee.FirstName);
				LastName.Clear();
				LastName.SendKeys(updatedEmployee.LastName);
				StartDate.Clear();
				StartDate.SendKeys(updatedEmployee.StartDate);
				Email.Clear();
				Email.SendKeys(updatedEmployee.Email);
				UpdateButton.Submit();
			}
			else
			{
				BackButton.Click();
			}
			return new HomePage(_driver);
		}

		public HomePage DeleteEmployee(Employee employee)
		{
			if (VerifyEmployeeDetails(employee))
			{
				DeleteButton.Click();
				AlertAccept();
			}
			else
			{
				BackButton.Click();
			}
			return new HomePage(_driver);
		}

		public bool VerifyEmployeeDetails(Employee employee)
		{
			return FirstName.GetAttribute("value") == employee.FirstName
					&& LastName.GetAttribute("value") == employee.LastName
					&& StartDate.GetAttribute("value") == employee.StartDate
					&& Email.GetAttribute("value") == employee.Email;
		}
	}
}
