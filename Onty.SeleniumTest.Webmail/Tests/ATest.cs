using System;
using System.Threading;

using NUnit.Framework;

using OpenQA.Selenium;

using Onty.SeleniumTest.Webmail.PageObjects;
using Onty.SeleniumTest.Webmail.Util;


namespace Onty.SeleniumTest.Webmail.Tests
{

	[TestFixture]
	public abstract class ATest
	{
		protected IWebDriver driver;

		[SetUp]
		public void Setup()
		{
			this.driver = WebDriverFactory.GetWebDriver();	// uses value from app.config
		}

		[TearDown]
		public void Teardown()
		{
			driver.Quit();
		}

	}

}//ns

