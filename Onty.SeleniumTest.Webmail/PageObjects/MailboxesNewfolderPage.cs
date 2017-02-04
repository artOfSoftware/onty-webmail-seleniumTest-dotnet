using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class MailboxesNewfolderPage : CommonPageElements
	{

		[FindsBy( How = How.Id, Using = "folder_name" )]
		[CacheLookup]
		protected IWebElement FieldFolderName { get; set; }

		[FindsBy( How = How.CssSelector, Using = "div.actions > input" )]
		[CacheLookup]
		protected IWebElement ButtonCreateFolder { get; set; }


		public MailboxesNewfolderPage( IWebDriver driver ) : base( driver )
		{
			if ( !CheckIfUrlMatches( "mailboxes/newfolder", 10 ) )
				throw new WrongPageException( "expecting Mailboxes/Newfolder page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "New Folder" )
				throw new WrongPageException( "expecting Mailboxes/Newfolder page (h1 text is wrong)" );

		}


		public MailboxesFolderPage CreateFolder( Folder folder )
		{
			FieldFolderName.SendKeys( folder.name );
			ButtonCreateFolder.Click();

			WaitForPageToLoad();

			return new MailboxesFolderPage( driver );
		}

	}

}//ns
