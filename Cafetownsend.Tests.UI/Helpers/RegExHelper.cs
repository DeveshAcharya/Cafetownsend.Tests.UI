using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cafetownsend.Tests.UI.Helpers
{
	public class RegExHelper
	{
		public MatchCollection GetLoginDetails(string loginInfo)
		{
			var reg = new Regex("\".*?\"");
			var loginDetails = reg.Matches(loginInfo);
			return loginDetails;
		}
	}
}
