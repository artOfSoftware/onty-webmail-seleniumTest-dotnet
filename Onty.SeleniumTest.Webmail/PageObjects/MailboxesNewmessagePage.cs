using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class MailboxesNewmessagePage : CommonPageElements
	{

		public MailboxesNewmessagePage( IWebDriver driver ) : base( driver )
		{
			if ( !CheckIfUrlMatches( "mailboxes/new", 10 ) )
				throw new WrongPageException( "expecting Mailboxes/Newmessage page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( FirstH1Text.Text != "New Message" )
				throw new WrongPageException( "expecting Mailboxes/Index page (h1 text is wrong)" );

		}


		public bool CheckFromInfo ( User user )
		{
			IWebElement from = driver.FindElement( By.CssSelector("form#new_message tr > td:nth-of-type(2)" ) );
			string fromText = from.Text;
			string expectedFromText = user.fullName + " (" + user.name + ")";

			return ( fromText == expectedFromText );
		}

		public MailboxesPage SendMessage( User toUser, string subject, string message )
		{
			// select to user
			// TODO: the test code below is not working properly...
			IWebElement toDropdown = driver.FindElement( By.Id( "message_to_id" ) );
			SelectElement select = new SelectElement(toDropdown);
			select.SelectByValue( toUser.id.ToString() );

			//IWebElement toOption = toDropdown.FindElement( By.XPath( "//option[@value='" + toUser.id + "']" ) );
			//toOption.Click();

			// type subject
			IWebElement subjectTextbox = driver.FindElement( By.Id("message_subject"));
			subjectTextbox.SendKeys( subject );

			// type message
			IWebElement messageTextbox = driver.FindElement( By.Id("message_text"));
			messageTextbox.SendKeys( message );

			// click create message
			IWebElement createButton = driver.FindElement( By.CssSelector("input#send"));
			createButton.Click();

			WaitForPageToLoad();

			return new MailboxesPage( driver );
		}

		//public bool CheckYourInfo( User user )
		//{
		//	return ( driver.PageSource.Contains( "User name: " + user.name ) );
		//}
	}

}//ns
