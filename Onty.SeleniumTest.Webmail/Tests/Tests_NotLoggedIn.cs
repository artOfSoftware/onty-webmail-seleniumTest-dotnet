using System;
using System.Threading;

using NUnit.Framework;

using OpenQA.Selenium;

using Onty.SeleniumTest.Webmail.PageObjects;
using Onty.SeleniumTest.Webmail.Util;


namespace Onty.SeleniumTest.Webmail.Tests
{

	[TestFixture]
	public class Tests_NotLoggedIn : ATest
	{

		[Test]
		[Order( 0 )]
		public void Test_NotLoggedIn_Home()
		{
			var loginPage = AccountsLoginPage.Go(driver);
			Assert.IsTrue( loginPage.CheckTextNotloggedin(), "not-logged-in message is not displayed" );
		}

	}

}//ns

