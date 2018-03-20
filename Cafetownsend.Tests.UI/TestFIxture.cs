using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;

namespace Cafetownsend.Tests.UI
{
	public class TestFixture : IDisposable
	{
		internal NgWebDriver NgDriver { get; }
		internal IWebDriver Driver { get; }

		public TestFixture()
		{
			Driver = new ChromeDriver();
			Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
			NgDriver = new NgWebDriver(Driver) {Url = "http://cafetownsend-angular-rails.herokuapp.com/login"};
		}

		public void Dispose()
		{
			Driver.Quit();
			Driver.Dispose();
		}
	}
}
