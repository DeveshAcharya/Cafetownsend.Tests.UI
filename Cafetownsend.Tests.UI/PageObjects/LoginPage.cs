using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cafetownsend.Tests.UI.Helpers;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;

namespace Cafetownsend.Tests.UI.PageObjects
{
	public class LoginPage:PageBase
	{
		private readonly IWebDriver _driver;

		public LoginPage(IWebDriver driver) :base (driver)
		{
			this._driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "user.name")]
		public IWebElement UserName { get; set; }

		[FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModel), Using = "user.password")]
		public IWebElement Password { get; set; }

		[FindsBy(How = How.CssSelector, Using = "#login-form > fieldset > button")]
		public IWebElement LoginButton { get; set; }

		
		[FindsBy(How = How.CssSelector, Using = "#login-form > fieldset > p.info")]
		public IWebElement LoginInfo { get; set; }

		public HomePage Login()
		{
			var loginDetails = new RegExHelper().GetLoginDetails(LoginInfo.Text);
			UserName.SendKeys(loginDetails[0].Value.Trim('"'));
			Password.SendKeys(loginDetails[1].Value.Trim('"'));
			LoginButton.Submit();
			return new HomePage(_driver);
		}
	}
}
