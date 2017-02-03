using System;
using System.Threading;

using NUnit.Framework;

using OpenQA.Selenium;

using Onty.SeleniumTest.Webmail.PageObjects;
using Onty.SeleniumTest.Webmail.Util;
using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.Tests
{

	[TestFixture]
	public class Tests_Login : ATest
	{

		[Test]
		public void Test_Login_Invalid()
		{
			User invalidUser = TestData.UsersInvalid[0];

			var loginPage = AccountsLoginPage.Go(driver);
			loginPage = loginPage.LoginAsInvalid( invalidUser );

			Assert.IsTrue( loginPage.CheckTextNotloggedin(),   "not-logged-in message not displayed in Accounts Login" );
			Assert.IsTrue( loginPage.CheckErrorInvalidLogin(), "invalid-login Error Flash not displayed in Accounts Login" );

		}

		[Test]
		public void Test_Login_Valid()
		{
			User validUser = TestData.UsersValid[0];

			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( validUser );

			// check the page text
			Assert.IsTrue( homePage.CheckLoggedinMessage(),     "logged-in Notice Flash not displayed in Accounts Home" );
			Assert.IsTrue( homePage.CheckNoticeValidLogin(),    "logged-in message not displayed in Accounts Home" );
			Assert.IsTrue( homePage.CheckYourInfo( validUser ), "correct user name not displayed under Your Info in Accounts Home" );


		}

	}

}//ns
