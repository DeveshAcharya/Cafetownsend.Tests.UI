using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Protractor;

namespace Cafetownsend.Tests.UI.PageObjects
{
	public class PageBase
	{
		private readonly NgWebDriver ngDriver;
		public PageBase(IWebDriver driver)
		{
			ngDriver = driver as NgWebDriver;
			WaitForLoad();
			
		}

		private void WaitForLoad()
		{
			ngDriver.WaitForAngular();
		}

		public void ScrollTo(IWebElement element)
		{
			var jse = (IJavaScriptExecutor)ngDriver;
			jse.ExecuteScript("arguments[0].scrollIntoView()", element);
		}

		public void AlertAccept()
		{
			ngDriver.SwitchTo().Alert().Accept();
		}

		public void AlertDismiss()
		{
			ngDriver.SwitchTo().Alert().Dismiss();
		}
	}
}
