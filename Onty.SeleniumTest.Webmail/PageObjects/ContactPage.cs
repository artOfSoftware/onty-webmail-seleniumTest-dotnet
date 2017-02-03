using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Onty.SeleniumTest.Webmail.PageObjects
{

	class ContactPage : APage
	{
		[FindsBy( How = How.TagName, Using = "h2" )]
		[CacheLookup]
		private IWebElement FirstH2Text { get; set; }

		[FindsBy( How = How.LinkText, Using = "Contact" )]
		[CacheLookup]
		private IWebElement ContactMenuItem { get; set; }


		public ContactPage( IWebDriver driver ) : base(driver)
		{
			// make sure we are on Home Page
			if ( !driver.Url.EndsWith( "media.annatoom.com/Contact" ) )
				throw new WrongPageException("expecting contact page (check 1)");

			PageFactory.InitElements( driver, this );

			// another check
			if ( FirstH2Text.Text != "Contact" )
				throw new WrongPageException( "expecing contact page (check 2)" );
		}

		//public LoginPage ClickOnMyAccount()
		//{
		//	ContactMenuItem.Click();

		//	Thread.Sleep( 4000 );

		//	return new ContactPage(driver);
		//}

	}

}//ns
