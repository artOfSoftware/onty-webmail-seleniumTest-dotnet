using System;
using System.Threading;

using NUnit.Framework;

using Onty.SeleniumTest.Webmail.PageObjects;
using Onty.SeleniumTest.Webmail.Util;
using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.Tests
{

	[TestFixture]
	public class Tests_Mailbox : ATest
	{

		[Test]
		public void Test_Mailbox_Home()
		{
			User user = TestData.UsersValid[0];

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// actual test
			var mailboxPage = homePage.ClickMenuMailbox();
			Assert.IsTrue( mailboxPage.CheckText( user ), "page content failed validation" );
		}

		[Test]
		public void Test_Mailbox_SendMessage()
		{
			User user = TestData.UsersValid[0];
			User user2 = TestData.UsersValid[1];

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// actual test
			var newmessagePage = homePage.ClickMenuNewmessage();
			newmessagePage.CheckFromInfo( user );
			var mailboxPage = newmessagePage.SendMessage( user2, "hello", "This is a simple hello message." );
		}

		//[Test]
		//public void Test_Mailbox_Logout()
		//{
		//	User user = TestData.UsersValid[0];

		//	// login
		//	var loginPage = new AccountsLoginPage(driver);
		//	var homePage = loginPage.LoginAsValid( user );

		//	// actual test
		//	loginPage = homePage.ClickMenuLogout();

		//	Assert.IsTrue( loginPage.CheckTextNotloggedin(),		"not-logged-in message not displayed in Accounts/Login" );
		//	Assert.IsTrue( loginPage.CheckNoticeMessageLoggedOut(),	"logged-out Notice flash not displayed in Accounts" );
		//}


	}

}//ns
