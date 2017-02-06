using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class AccountsHomePage : CommonPageElements
	{

		public AccountsHomePage( IWebDriver driver ) : base( driver )
		{
			if ( !CheckIfUrlContains( "accounts/home", 10 ) )
				throw new WrongPageException( "expecting home page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "Account Home" )
				throw new WrongPageException( "expecting home page (h1 text is wrong)" );

		}


		public bool CheckLoggedinMessage()
		{
			return FirstParagraph.Text == "You are currently logged in.";
		}

		public bool CheckNoticeValidLogin()
		{
			return ( MessageNotice.Displayed && MessageNotice.Text == "Notice: Login Successful" );
		}

		public bool CheckYourInfo( User user )
		{
			return ( driver.PageSource.Contains( "User name: " + user.name ) );
		}

		public bool CheckNoticeAccountcreated( User newUser )
		{
			return ( MessageNotice.Displayed && 
				MessageNotice.Text == "Notice: Account " + newUser.name + " created!" );
		}

	}

}//ns
