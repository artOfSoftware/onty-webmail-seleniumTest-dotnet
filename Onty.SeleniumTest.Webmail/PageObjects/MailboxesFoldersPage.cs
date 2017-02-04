using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class MailboxesFoldersPage : CommonPageElements
	{

		[FindsBy( How = How.Id, Using = "create-folder" )]
		[CacheLookup]
		protected IWebElement LinkCreateFolder { get; set; }


		public MailboxesFoldersPage( IWebDriver driver ) : base( driver )
		{
			if ( !CheckIfUrlMatches( "mailboxes/folders", 10 ) )
				throw new WrongPageException( "expecting Mailboxes/Folders page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "View Folders" )
				throw new WrongPageException( "expecting Mailboxes/Folders page (h1 text is wrong)" );

		}


		public MailboxesNewfolderPage ClickLinkNewfolder()
		{
			LinkCreateFolder.Click();

			WaitForPageToLoad();

			return new MailboxesNewfolderPage( driver );
		}

	}

}//ns
