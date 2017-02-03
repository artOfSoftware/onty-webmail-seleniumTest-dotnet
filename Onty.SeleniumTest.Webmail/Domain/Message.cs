using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Onty.SeleniumTest.Webmail.Domain
{
	public class Message
	{

		public int  id;
		public User from;
		public User to;
		public User mailbox;
		public string subject;
		public string text;

	}
}
