using System;
using System.Collections.Generic;
using System.Text;


namespace Onty.SeleniumTest.Webmail.Domain
{
	public class Folder
	{

		public int    id;
		public string name;


		public enum Builtin
		{
			Inbox = 1,
			Sent = 2,
			Archived = 3,
		}

		public static string GetNameFor( Builtin folderType )
		{
			return folderType.ToString();
		}

	}

}//ns
