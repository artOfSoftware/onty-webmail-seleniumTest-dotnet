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

		internal bool CheckIfMessageIsListed( Message message )
		{
			var rows = driver.FindElements( By.CssSelector( "table tr" ) );

			bool found = false;
			foreach ( IWebElement row in rows )
			{
				string from    = row.FindElement(By.XPath("//td/a" )).Text;
				string to      = row.FindElement(By.XPath("//td[2]/a" )).Text;
				string subject = row.FindElement(By.XPath("//td[3]" )).Text;
				//string text    = row.FindElement(By.XPath("td[4]" )).Text;

				// TODO: this currently does not work. i thought chaining locators would cause a subcontext, but it does not seem to work this way...

				if ( from == message.from.DisplayName &&
					 to == message.to.DisplayName &&
					 subject == message.subject )
				{
					found = true;
					break;
				}
			}

			return found;
		}

		//public bool CheckYourInfo( User user )
		//{
		//	return ( driver.PageSource.Contains( "User name: " + user.name ) );
		//}
	}

}//ns
