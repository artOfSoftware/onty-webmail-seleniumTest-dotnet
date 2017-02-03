﻿using System;
using System.Threading;

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

			if ( FirstH1Text.Text.Contains( "View Mailbox: Folder" ) )
				throw new WrongPageException( "expecting Mailboxes/Folder page (h1 text is wrong)" );

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
