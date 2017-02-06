using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class AccountsLoginPage : CommonPageElements
	{

		[FindsBy( How = How.Id, Using = "user_name" )]
		[CacheLookup]
		private IWebElement UsernameField { get; set; }

		[FindsBy( How = How.Id, Using = "user_password" )]
		[CacheLookup]
		private IWebElement PasswordField { get; set; }

		[FindsBy( How = How.Id, Using = "login" )]
		[CacheLookup]
		private IWebElement LoginButton { get; set; }


		public AccountsLoginPage( IWebDriver driver ) : base(driver)
		{
			if ( ! CheckIfUrlContains( "accounts/login", 10 ) )
				throw new WrongPageException( "expecting login page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "Account Login" )
				throw new WrongPageException( "expecting login page (h1 text is wrong)" );

		}

		public static AccountsLoginPage Go( IWebDriver driver )
		 {
			driver.Url = Properties.Settings.Default.BaseUrl + "/accounts/login" ;

			return new AccountsLoginPage( driver );

		}


		public AccountsHomePage LoginAsValid( User validUser )
		{
			if ( !IsDisplayed( By.Id( "user_name" ), 10 ) )
				throw new ElementNotVisibleException( "cannot find login field" );

			UsernameField.SendKeys( validUser.name );
			PasswordField.SendKeys( validUser.password );
			LoginButton.Click();

			WaitForPageToLoad();

			return new AccountsHomePage( driver );
		}

		public AccountsLoginPage LoginAsInvalid( User invalidUser )
		{
			if ( !IsDisplayed( By.Id( "user_name" ), 10 ) )
				throw new ElementNotVisibleException( "cannot find login field" );

			UsernameField.SendKeys( invalidUser.name );
			PasswordField.SendKeys( invalidUser.password );
			LoginButton.Click();

			WaitForPageToLoad();

			return new AccountsLoginPage( driver );
		}


		public bool CheckTextNotloggedin()
		{
			return FirstParagraph.Text == "User is not logged in.";
		}

		public bool CheckErrorInvalidLogin()
		{
			return ( MessageError.Displayed && MessageError.Text == "Error: Login unsuccessful" );
		}

		public bool CheckNoticeMessageLoggedOut()
		{
			return ( MessageNotice.Displayed && MessageNotice.Text == "Notice: Logged out" );
		}


	}

}//ns
