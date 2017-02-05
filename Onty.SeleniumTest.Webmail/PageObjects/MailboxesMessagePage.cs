using System;
using System.Threading;
using System.Text.RegularExpressions;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using Onty.SeleniumTest.Webmail.Domain;

namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public class MailboxesMessagePage : CommonPageElements
	{

		[FindsBy( How = How.CssSelector, Using = "table tr > td:nth-of-type(2)" )]
		[CacheLookup]
		protected IWebElement MessageId { get; set; }

		[FindsBy( How = How.CssSelector, Using = "table tr:nth-of-type(2) > td:nth-of-type(2)" )]
		[CacheLookup]
		protected IWebElement MessageInFolder { get; set; }

		[FindsBy( How = How.CssSelector, Using = "table tr:nth-of-type(3) > td:nth-of-type(2)" )]
		[CacheLookup]
		protected IWebElement MessageFrom { get; set; }

		[FindsBy( How = How.CssSelector, Using = "table tr:nth-of-type(4) > td:nth-of-type(2)" )]
		[CacheLookup]
		protected IWebElement MessageTo { get; set; }

		[FindsBy( How = How.CssSelector, Using = "table tr:nth-of-type(5) > td:nth-of-type(2)" )]
		[CacheLookup]
		protected IWebElement MessageSubject { get; set; }

		[FindsBy( How = How.CssSelector, Using = "table tr:nth-of-type(6) > td:nth-of-type(2)" )]
		[CacheLookup]
		protected IWebElement MessageStatus { get; set; }

		[FindsBy( How = How.CssSelector, Using = "table tr:nth-of-type(7) > td:nth-of-type(2)" )]
		[CacheLookup]
		protected IWebElement MessageText { get; set; }

		public MailboxesMessagePage( IWebDriver driver ) : base( driver )
		{
			if ( !CheckIfUrlMatches( "mailboxes/[0-9]+/message", 10 ) )
				throw new WrongPageException( "expecting Mailboxes/Message page (wrong url)" );

			PageFactory.InitElements( driver, this );

			if ( !FirstH1Text.Text.Contains( "View a Message" ) )
				throw new WrongPageException( "expecting Mailboxes/Message page (h1 text is wrong)" );
		}


		public int GetMessageId()
		{
			string url = driver.Url;
			Regex regex = new Regex("/mailboxes/([0-9]+)/message");
			Match match = regex.Match( url );
			string idStr = match.Groups[1].Captures[0].Value;
			int id = int.Parse(idStr);

			return id;
		}

		//public bool CheckNoticeFolderCreated()
		//{
		//	return ( MessageNotice.Displayed && MessageNotice.Text == "Notice: Folder was created successfully" );
		//}

		internal bool CheckMessageDetails( Message message )
		{
			string id      = MessageId      .Text;
			string folder  = MessageInFolder.Text;
			string from    = MessageFrom    .Text;
			string to      = MessageTo      .Text;
			string subject = MessageSubject .Text;
			string text    = MessageText    .Text;

			return  ( id == message.id.ToString() ) &&
					( from == message.from.DisplayName ) &&
					( to == message.to.DisplayName ) &&
					( subject == message.subject ) &&
					( text == message.text );
		}

	}

}//ns
