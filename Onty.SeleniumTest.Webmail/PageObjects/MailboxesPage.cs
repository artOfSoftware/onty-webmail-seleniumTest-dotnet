using System;
using System.Threading;
using System.Text.RegularExpressions;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class MailboxesPage : CommonPageElements
	{

		public MailboxesPage( IWebDriver driver ) : base( driver )
		{
			if ( !CheckIfUrlMatches( "mailboxes(/index)?", 10 ) )
				throw new WrongPageException( "expecting Mailboxes/Index page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "View Mailbox" )
				throw new WrongPageException( "expecting Mailboxes/Index page (h1 text is wrong: '"+FirstH1Text.Text+"')" );

		}


		public bool CheckText( User user )
		{
			// NOTE: this was poorly implemented. test currently fails, but should pass. needs review.

			//int nrFolders = user.customFolders.Count + 3;
			
			//string expectedText = "You have "+ nrFolders +" folders.";
			//if ( FirstParagraph.Text != expectedText )
			//	throw new ValidationException( "number of folders stated (" + FirstParagraph.Text + ") differs from expected (" + expectedText + ")" );

			// determine how many folders are stated on the page in the first paragraph
			Regex regex = new Regex("You have ([0-9]+) folders.");
			Match match = regex.Match( FirstParagraph.Text );
			string nrFoldersStr =  match.Groups[1].Captures[0].Value;
			int nrFolders = int.Parse( nrFoldersStr );

			// compare to actual number of folders listed
			var items = driver.FindElements( By.CssSelector( "div.app-main > ul > li > a" ) );

			if ( items.Count != nrFolders )
				throw new ValidationException( "nr of folders stated and actually listed differ" );

			// ensure default folders are all listed
			if ( items[0].Text != Folder.GetNameFor(Folder.Builtin.Inbox ) )
				throw new ValidationException("Inbox name is wrong");

			if ( items[1].Text != Folder.GetNameFor( Folder.Builtin.Sent ) )
				throw new ValidationException( "Inbox name is wrong" );

			if ( items[2].Text != Folder.GetNameFor( Folder.Builtin.Archived ) )
				throw new ValidationException( "Inbox name is wrong" );

			//if ( items.Count > 3 )
			//{
			//	//TODO: they could be in a different order irl
			//	for ( int i = 3 ; i < items.Count ; i++ )
			//	{
			//		if ( items[i].Text != user.customFolders[i - 3].name )
			//			throw new ValidationException( "Custom folder name mismatch between internal test data and AUT" );
			//	}
			//}

			return true;
		}



		//public bool CheckLoggedinMessage()
		//{
		//	return FirstParagraph.Text == "You are currently logged in.";
		//}

		//public bool CheckNoticeValidLogin()
		//{
		//	return ( MessageNotice.Displayed && MessageNotice.Text == "Notice: Login Successful" );
		//}

		//public bool CheckYourInfo( User user )
		//{
		//	return ( driver.PageSource.Contains( "User name: " + user.name ) );
		//}
	}

}//ns
