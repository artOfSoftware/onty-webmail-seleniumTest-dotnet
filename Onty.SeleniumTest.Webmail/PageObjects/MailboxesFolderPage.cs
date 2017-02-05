using System;
using System.Threading;
using System.Text.RegularExpressions;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;

namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class MailboxesFolderPage : CommonPageElements
	{

		public MailboxesFolderPage( IWebDriver driver ) : base( driver )
		{
			if ( !CheckIfUrlMatches( "mailboxes/[0-9]+/folder", 10 ) )
				throw new WrongPageException( "expecting Mailboxes/Folder page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( !FirstH1Text.Text.Contains( "View Mailbox: Folder" ) )
				throw new WrongPageException( "expecting Mailboxes/Folder page (h1 text is wrong)" );

		}


		public bool CheckFolderName( Folder folder )
		{
			return FirstH1Text.Text.Contains( folder.name );
		}

		public bool CheckFolderName( Folder.Builtin folder )
		{
			return FirstH1Text.Text.Contains( Folder.GetNameFor(folder) );
		}

		public int GetFolderId()
		{
			string url = driver.Url;
			Regex regex = new Regex("/mailboxes/([0-9]+)/folder");
			Match match = regex.Match( url );
			string idStr = match.Groups[1].Captures[0].Value;
			int id = int.Parse(idStr);

			return id;
		}

		public bool CheckNoticeFolderCreated()
		{
			return ( MessageNotice.Displayed && MessageNotice.Text == "Notice: Folder was created successfully" );
		}

		public bool CheckIfMessageIsListed( Message message )
		{
			return GetRowIdOfMessage(message).HasValue;
		}

		public MailboxesMessagePage ClickMessageRead( Message message )
		{
			int? rowId = GetRowIdOfMessage( message );
			if ( !rowId.HasValue )
				throw new ArgumentException( "Cannot click message's Read button because message is not listed in folder" );

			IWebElement linkRead = driver.FindElement(By.CssSelector("table tr:nth-of-type("+rowId.Value+") > td:nth-of-type(5) > a" ));
			linkRead.Click();

			WaitForPageToLoad();

			return new MailboxesMessagePage( driver );
		}

		protected int? GetRowIdOfMessage( Message message )
		{
			int nrMessages = driver.FindElements( By.CssSelector( "table tr" ) ).Count - 1;

			int? rowId = null;
			for ( int i = 1 ; i <= nrMessages ; i++ )
			{
				string from    = driver.FindElement(By.CssSelector("table tr:nth-of-type("+i+") > td > a" )).Text;
				string to      = driver.FindElement(By.CssSelector("table tr:nth-of-type("+i+") > td:nth-of-type(2) > a" )).Text;
				string subject = driver.FindElement(By.CssSelector("table tr:nth-of-type("+i+") > td:nth-of-type(3)" )).Text;

				if ( from    == message.from.DisplayName &&
					 to      == message.to.DisplayName &&
					 subject == message.subject )
				{
					rowId = i;
					break;
				}
			}

			return rowId;
		}


	}

}//ns
