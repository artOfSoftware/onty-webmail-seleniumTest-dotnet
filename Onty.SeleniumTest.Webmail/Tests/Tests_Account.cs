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

		//TODO: this is not really an account test. where should it be?
		[Test]
		[Order( 1 )]
		public void Test_Unk_Menu()
		{
			User user = TestData.UsersValid[0];

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// check the menu
			Assert.IsTrue( loginPage.CheckMenu(user), "validation of menu failed" );
		}

	}

}//ns
