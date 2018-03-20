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
	public class CreateEmployeePage: PageBase
	{
		private IWebDriver _driver;

		public CreateEmployeePage(IWebDriver driver):base(driver)
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

		[FindsBy(How = How.XPath, Using = "/ html / body / div / div / div / form / fieldset / div / button[2]")]
		public IWebElement AddButton { get; set; }

		public HomePage CreateEmployee(Employee employee)
		{
			FirstName.SendKeys(employee.FirstName);
			LastName.SendKeys(employee.LastName);
			StartDate.SendKeys(employee.StartDate);
			Email.SendKeys(employee.Email);
			AddButton.Submit();
			return new HomePage(_driver);

		}
	}
}
