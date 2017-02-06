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
	public class Tests_NotLoggedIn : ATest
	{

		[Test]
		[Order( 0 )]
		public void Test_NotLoggedIn_Home()
		{
			var loginPage = AccountsLoginPage.Go(driver);
			Assert.IsTrue( loginPage.CheckTextNotloggedin(), "not-logged-in message is not displayed" );
		}

		[Test]
		[Order( 0 )]
		public void Test_NotLoggedIn_CreateAccount()
		{
			var loginPage = AccountsLoginPage.Go(driver);
			var signupPage = loginPage.ClickSignup();

			string rndstr = StringUtil.MakeRandomString();

			User newUser = new User()
			{
				name     = "newuser_" + rndstr,
				fullName = "New User " + rndstr,
				email    = rndstr + "@here.com",
				password = rndstr,
			};

			var homePage = signupPage.SignupValid( newUser );
			Assert.IsTrue( homePage.CheckNoticeAccountcreated( newUser), "account created notice not displayed" );
			Assert.IsTrue( homePage.CheckLoggedinMessage(), "regular logged-in message not displayed" );
			Assert.IsTrue( homePage.CheckYourInfo(newUser), "Your Info validation failed" );
		}



	}

}//ns

