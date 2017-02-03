using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class AccountsUsersPage : CommonPageElements
	{

		public AccountsUsersPage( IWebDriver driver ) : base(driver)
		{
			if ( ! CheckIfUrlContains( "accounts/users", 10 ) )
				throw new WrongPageException( "expecting Accounts/Users page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "Listing of Users" )
				throw new WrongPageException( "expecting Account/Users page (h1 text is wrong)" );

		}

		public bool CheckTextIsUserListed( string username )
		{
			try
			{
				IWebElement linkWithUsername = driver.FindElement( By.LinkText(username) );
				return ( linkWithUsername.Displayed && linkWithUsername.Enabled );
			}
			catch ( NoSuchElementException )
			{
				return false;
			}
		}

		public AccountsUserPage ClickLinkUser( string username )
		{
			IWebElement linkWithUsername = driver.FindElement( By.LinkText(username) );
			linkWithUsername.Click();
			WaitForPageToLoad();
			return new AccountsUserPage( driver );
		}

	}

}//ns
