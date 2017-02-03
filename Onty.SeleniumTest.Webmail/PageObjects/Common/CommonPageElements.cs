using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class CommonPageElements : APage
	{
		[FindsBy( How = How.TagName, Using = "h1" )]
		[CacheLookup]
		protected IWebElement FirstH1Text { get; set; }

		[FindsBy( How = How.CssSelector, Using = "div.app-main > p" )]
		[CacheLookup]
		protected IWebElement FirstParagraph { get; set; }

		[FindsBy( How = How.CssSelector, Using = "div.error" )]
		[CacheLookup]
		protected IWebElement MessageError { get; set; }

		[FindsBy( How = How.CssSelector, Using = "div.notice" )]
		[CacheLookup]
		protected IWebElement MessageNotice { get; set; }


		// Menu Items

		[FindsBy( How = How.CssSelector, Using = "a#nav-Accounts" )]
		[CacheLookup]
		protected IWebElement LinkAccount { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Accounts-password" )]
		[CacheLookup]
		protected IWebElement LinkAccountPassword { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Accounts-logout" )]
		[CacheLookup]
		protected IWebElement LinkAccountLogout { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Accounts-users" )]
		[CacheLookup]
		protected IWebElement LinkAccountUsers { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Mailboxes-index" )]
		[CacheLookup]
		protected IWebElement LinkMailbox { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Mailboxes-new-message" )]
		[CacheLookup]
		protected IWebElement LinkMailboxNewmessage { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Mailboxes-folders" )]
		[CacheLookup]
		protected IWebElement LinkMailboxFolders { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Mailboxes-view-folder-1" )]
		[CacheLookup]
		protected IWebElement LinkMailboxFoldersInbox { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Mailboxes-view-folder-2" )]
		[CacheLookup]
		protected IWebElement LinkMailboxFoldersSent { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#nav-Mailboxes-view-folder-3" )]
		[CacheLookup]
		protected IWebElement LinkMailboxFoldersArchived { get; set; }

		[FindsBy( How = How.CssSelector, Using = "a#logout" )]
		[CacheLookup]
		protected IWebElement LinkLogout { get; set; }

		//TODO: there are more folders


		// Ctor

		public CommonPageElements( IWebDriver driver ) : base(driver)
		{
			string url = driver.Url;
		}


		// member functions

		public AccountsUsersPage ClickMenuUsers()
		{
			LinkAccountUsers.Click();
			WaitForPageToLoad();
			return new AccountsUsersPage( driver );
		}
		
		public AccountsLoginPage ClickMenuLogout()
		{
			LinkAccountLogout.Click();
			WaitForPageToLoad();
			return new AccountsLoginPage( driver );
		}

		public AccountsPasswordPage ClickMenuPassword()
		{
			LinkAccountPassword.Click();
			WaitForPageToLoad();
			return new AccountsPasswordPage( driver );
		}

		public MailboxesPage ClickMenuMailbox()
		{
			LinkMailbox.Click();
			WaitForPageToLoad();
			return new MailboxesPage( driver );
		}

		public MailboxesNewmessagePage ClickMenuNewmessage()
		{
			LinkMailboxNewmessage.Click();
			WaitForPageToLoad();
			return new MailboxesNewmessagePage( driver );
		}

		public MailboxesFoldersPage ClickMenuFolders()
		{
			LinkMailboxFolders.Click();
			WaitForPageToLoad();
			return new MailboxesFoldersPage( driver );
		}

		public MailboxesFolderPage ClickMenuFolder( Folder.Builtin folderType )
		{
			if ( folderType == Folder.Builtin.Inbox )
				LinkMailboxFoldersInbox.Click();
			else if ( folderType == Folder.Builtin.Sent )
				LinkMailboxFoldersSent.Click();
			else if ( folderType == Folder.Builtin.Archived )
				LinkMailboxFoldersArchived.Click();
			else
				throw new ArgumentException( "Unknown folder requested" );

			WaitForPageToLoad();
			return new MailboxesFolderPage( driver );
		}

		public MailboxesFolderPage ClickMenuFolder( Folder folder )
		{
			driver.FindElement( By.LinkText( folder.name ) ).Click();
			// TODO: might be better to select by folder id?

			WaitForPageToLoad();
			return new MailboxesFolderPage( driver );
		}



		// validation functions
		public bool CheckMenu( User user )
		{
			IWebElement menu = driver.FindElement( By.ClassName( "app-navigation-global" ) );

			// check welcome text
			string welcomeText = menu.FindElement( By.XPath( "p" ) ).Text;
			string expectedWelcomeText = "Welcome, " + user.fullName + " (" + user.name + ")";
			if ( welcomeText != expectedWelcomeText )
				throw new ValidationException( "Welcome text validation failed" );

			//TODO: anything else needs to be tested here?

			return true;
		}



		// helper functions


		protected bool WaitForPageToLoad( double timeoutS = 1.0 )
		{
			Thread.Sleep( (int)( timeoutS * 1000 ) );

			//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutS));
			//wait.Until( ( wdriver ) =>
			//	( wdriver as IJavaScriptExecutor ).ExecuteScript( "return document.readyState" ).Equals( "complete" )
			//);

			// TODO: need a try-catch block here?

			return true;
		}


		protected bool CheckIfUrlContains( string expectedUrlContains, int timeoutS )
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutS));

			try
			{
				wait.Until( ExpectedConditions.UrlContains( expectedUrlContains ) );
				return true;
			}
			catch ( WebDriverTimeoutException )
			{
				return false;
			}

		}

		protected bool CheckIfUrlMatches( string expectedUrlMatches, int timeoutS )
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutS));

			try
			{
				wait.Until( ExpectedConditions.UrlMatches( expectedUrlMatches ) );
				return true;
			}
			catch ( WebDriverTimeoutException )
			{
				return false;
			}

		}


	}

}//ns
