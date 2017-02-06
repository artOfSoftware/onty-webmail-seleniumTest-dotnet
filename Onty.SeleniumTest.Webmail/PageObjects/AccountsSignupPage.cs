using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class AccountsSignupPage : CommonPageElements
	{

		[FindsBy( How = How.Id, Using = "signup_name" )]
		[CacheLookup]
		private IWebElement UsernameField { get; set; }

		[FindsBy( How = How.Id, Using = "signup_fullname" )]
		[CacheLookup]
		private IWebElement FullnameField { get; set; }

		[FindsBy( How = How.Id, Using = "signup_email" )]
		[CacheLookup]
		private IWebElement EmailField { get; set; }

		[FindsBy( How = How.Id, Using = "signup_password" )]
		[CacheLookup]
		private IWebElement PasswordField { get; set; }

		[FindsBy( How = How.Id, Using = "signup_password_confirmation" )]
		[CacheLookup]
		private IWebElement Password2Field { get; set; }

		[FindsBy( How = How.Id, Using = "signup" )]
		[CacheLookup]
		private IWebElement SignupButton { get; set; }


		public AccountsSignupPage( IWebDriver driver ) : base(driver)
		{
			if ( ! CheckIfUrlContains( "accounts/signup", 10 ) )
				throw new WrongPageException( "expecting Account/Signup page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "Account Signup" )
				throw new WrongPageException( "expecting Accounts/Signup page (h1 text is wrong)" );
		}


		public AccountsHomePage SignupValid( User user )
		{
			UsernameField .SendKeys( user.name     );
			FullnameField .SendKeys( user.fullName );
			EmailField    .SendKeys( user.email    );
			PasswordField .SendKeys( user.password );
			Password2Field.SendKeys( user.password );

			SignupButton.Click();

			WaitForPageToLoad();

			return new AccountsHomePage( driver );
		}


		//public bool CheckErrorInvalidLogin()
		//{
		//	return ( MessageError.Displayed && MessageError.Text == "Error: Login unsuccessful" );
		//}

		//public bool CheckNoticeMessageLoggedOut()
		//{
		//	return ( MessageNotice.Displayed && MessageNotice.Text == "Notice: Logged out" );
		//}


	}

}//ns
