using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using System.Drawing.Imaging;


namespace Onty.SeleniumTest.Webmail.Util
{
	public static class ScreenShotUtil
	{

		public static void TakeScreenshot( IWebDriver driver, string comment )
		{
			Screenshot s = ((ITakesScreenshot)driver).GetScreenshot();

			string currTime = DateTime.Now.ToString(@"yyyyMMdd-HHmmss.ssssss");

			string filepath = @"c:\temp\" + currTime + "("+comment+").png";

			s.SaveAsFile( filepath, ImageFormat.Png );
		}

	}

}//ns

