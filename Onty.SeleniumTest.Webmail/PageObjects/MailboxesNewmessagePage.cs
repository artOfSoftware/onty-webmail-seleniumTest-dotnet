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
				throw new WrongPageException( "expecting Mailboxes/Newmessage page (h1 text is wrong)" );

		}


		public bool CheckFromInfo ( User user )
		{
			IWebElement from = driver.FindElement( By.CssSelector("form#new_message tr > td:nth-of-type(2)" ) );
			string fromText = from.Text;
			string expectedFromText = user.fullName + " (" + user.name + ")";

			return ( fromText == expectedFromText );
		}

		public MailboxesPage SendMessage( User toUser, Message message )
		{
			// select to user
			IWebElement toDropdown = driver.FindElement( By.Id( "message_to_id" ) );

			// SelectElement functionality is broken in Selenium :-(
			//SelectElement select = new SelectElement(toDropdown);
			//select.SelectByValue( toUser.id.ToString() );
			//select.SelectByText( toUser.DisplayName );
			//select.SelectByIndex( 2 );
			toDropdown.SendKeys( toUser.DisplayName + Keys.Enter );

			// type subject
			IWebElement subjectTextbox = driver.FindElement( By.Id("message_subject"));
			subjectTextbox.SendKeys( message.subject );

			// type message
			IWebElement messageTextbox = driver.FindElement( By.Id("message_text"));
			messageTextbox.SendKeys( message.text );

			// click create message
			IWebElement createButton = driver.FindElement( By.CssSelector("input#send"));
			createButton.Click();

			WaitForPageToLoad();

			return new MailboxesPage( driver );
		}

	}

}//ns
