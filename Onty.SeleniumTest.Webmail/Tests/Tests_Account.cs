using System;
using System.Threading;

using NUnit.Framework;

using Onty.SeleniumTest.Webmail.PageObjects;
using Onty.SeleniumTest.Webmail.Util;
using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.Tests
{

	[TestFixture]
	public class Tests_Account : ATest
	{

		[Test]
		[Order( 1 )]
		public void Test_Account_Users()
		{
			User user = TestData.UsersValid[0];

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// actual test
			var accountUsersPage = homePage.ClickMenuUsers();
			Assert.IsTrue( accountUsersPage.CheckTextIsUserListed( user.name ), "user '" + user.name + "' is not displayed in the user list on Accounts/Users" );

			var accountUserPage = accountUsersPage.ClickLinkUser( user.name );
			Assert.IsTrue( accountUserPage.CheckText( user ), "general check failed in Accounts/User" );
		}

		[Test]
		[Order( 1 )]
		public void Test_Account_Password()
		{
			User user = TestData.UsersValid[0];

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// actual test
			var accountPasswordPage = homePage.ClickMenuPassword();
		}

		[Test]
		[Order( 1 )]
		public void Test_Account_Logout()
		{
			User user = TestData.UsersValid[0];

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// actual test
			loginPage = homePage.ClickMenuLogout();

			Assert.IsTrue( loginPage.CheckTextNotloggedin(),		"not-logged-in message not displayed in Accounts/Login" );
			Assert.IsTrue( loginPage.CheckNoticeMessageLoggedOut(),	"logged-out Notice flash not displayed in Accounts" );
		}


		[Test]
		[Order( 1 )]
		public void Test_Account_CreateAccount()
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
			Assert.IsTrue( homePage.CheckNoticeAccountcreated( newUser ), "account created notice not displayed" );
			Assert.IsTrue( homePage.CheckLoggedinMessage(),               "regular logged-in message not displayed" );
			Assert.IsTrue( homePage.CheckYourInfo( newUser ),             "Your Info validation failed" );

			// now try to logout and log back in as the new user
			loginPage = homePage.ClickMenuLogout();
			loginPage.LoginAsValid( newUser );

			Assert.IsTrue( homePage.CheckLoggedinMessage(),   "logged-in Notice Flash not displayed in Accounts Home" );
			Assert.IsTrue( homePage.CheckNoticeValidLogin(),  "logged-in message not displayed in Accounts Home" );
			Assert.IsTrue( homePage.CheckYourInfo( newUser ), "correct user name not displayed under Your Info in Accounts Home" );
		}


	}

}//ns
