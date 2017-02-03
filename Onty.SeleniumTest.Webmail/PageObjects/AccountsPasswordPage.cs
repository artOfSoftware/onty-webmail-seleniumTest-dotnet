using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class AccountsPasswordPage : CommonPageElements
	{

		public AccountsPasswordPage( IWebDriver driver ) : base(driver)
		{
			if ( ! CheckIfUrlContains( "accounts/password", 10 ) )
				throw new WrongPageException( "expecting Accounts/Password page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "Account Password" )
				throw new WrongPageException( "expecting Account/Password page (h1 text is wrong)" );

		}

		public bool CheckText( User user )
		{
			try
			{
				IWebElement usernameElem = driver.FindElement( By.XPath("//table/tbody/tr[2]/td[2]") );
				string text = usernameElem.Text.Trim();
				if ( text != user.name )
					return false;

				IWebElement useridElem = driver.FindElement( By.XPath("//table/tbody/tr[1]/td[2]") );
				string id = useridElem.Text.Trim();
				if ( id != user.id.ToString() )
					return false;

				return true;
			}
			catch ( NoSuchElementException )
			{
				return false;
			}
		}



	}

}//ns
