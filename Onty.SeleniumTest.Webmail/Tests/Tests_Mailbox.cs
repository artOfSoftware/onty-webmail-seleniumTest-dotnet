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
		[Order(2)]
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
		[Order( 2 )]
		[Category("This test is not fully implemented")]
		public void Test_Mailbox_SendMessage()
		{
			User user = TestData.UsersValid[0];
			User user2 = TestData.UsersValid[1];

			Message message = new Message()
			{
				subject = "hello " + StringUtil.MakeRandomString(),
				text    = "This is a simple hello message for testing. "+ StringUtil.MakeRandomString(),
				from    = user,
				to      = user2,
			};

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// actual test
			var newmessagePage = homePage.ClickMenuNewmessage();
			Assert.IsTrue( newmessagePage.CheckFromInfo( user ), "from info is wrong" );
			var mailboxPage = newmessagePage.SendMessage( user2, message );

			// make sure message is in sent folder
			var sentFolderPage = mailboxPage.ClickMenuFolder(Folder.Builtin.Sent);
			sentFolderPage.CheckFolderName( Folder.Builtin.Sent );

			Assert.IsTrue( sentFolderPage.CheckIfMessageIsListed( message ), "sent message not listed in sent folder" );

			// view the actual message
			var messagePage = sentFolderPage.ClickMessageRead( message );
			message.id = messagePage.GetMessageId();
			Assert.IsTrue( messagePage.CheckMessageDetails( message ), "message details are wrong for sender" );


			loginPage = sentFolderPage.ClickMenuLogout();

			// login as recipient, and check inbox
			homePage = loginPage.LoginAsValid( user2 );
			Assert.IsTrue( homePage.CheckLoggedinMessage(), "valid login" );

			var inboxPage = homePage.ClickMenuFolder( Folder.Builtin.Inbox );
			Assert.IsTrue( inboxPage.CheckIfMessageIsListed( message ), "sent message is not listed in recipient's folder" );

			messagePage = inboxPage.ClickMessageRead( message );
			message.id = messagePage.GetMessageId();
			Assert.IsTrue( messagePage.CheckMessageDetails( message ), "message details are wrong for recipient" );
		}

		[Test]
		[Order( 2 )]
		public void Test_Mailbox_CreateFolder()
		{
			User user = TestData.UsersValid[0];
			Folder folder = new Folder() { name="my new custom folder " + StringUtil.MakeRandomString() };

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// actual test
			var foldersPage = homePage.ClickMenuFolders();
			var newfolderPage = foldersPage.ClickLinkNewfolder();
			var folderPage = newfolderPage.CreateFolder( folder );
			Assert.IsTrue( folderPage.CheckNoticeFolderCreated(), "Notice about successful creation of folder is missing" );

			folderPage.CheckFolderName( folder );
			folder.id = folderPage.GetFolderId();
			user.customFolders.Add( folder );
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
