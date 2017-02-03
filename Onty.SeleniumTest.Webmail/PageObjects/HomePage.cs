using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Onty.SeleniumTest.Webmail.PageObjects
{

	class HomePage : APage
	{
		[FindsBy( How = How.TagName, Using = "h1" )]
		[CacheLookup]
		private IWebElement FirstH1Text { get; set; }

		[FindsBy( How = How.CssSelector, Using = ".nav.navbar-nav > li > a" )]
		[CacheLookup]
		private IWebElement ContactMenuItem { get; set; }

		[FindsBy( How = How.CssSelector, Using = ".nav.navbar-nav > li:nth-of-type(2) > a" )]
		[CacheLookup]
		private IWebElement AboutMenuItem { get; set; }


		public HomePage( IWebDriver driver ) : base(driver)
		{
			// make sure we are on Home Page
			if ( !driver.Url.EndsWith( "media.annatoom.com/" ) )
				throw new WrongPageException("expecting home page (check 1)");

			PageFactory.InitElements( driver, this );

			// another check
			if ( FirstH1Text.Text != "Psychology Lectures Online" )
				throw new WrongPageException( "expecing home page (check 2)" );
		}

		public ContactPage ClickOnContact()
		{
			ContactMenuItem.Click();

			Thread.Sleep( 4000 );

			return new ContactPage(driver);
		}

		public AboutPage ClickOnAbout()
		{
			AboutMenuItem.Click();

			Thread.Sleep( 4000 );

			return new AboutPage( driver );
		}

	}

}//ns
