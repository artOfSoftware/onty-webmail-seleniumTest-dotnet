using System;
using System.Collections.Generic;
using System.Text;


namespace Onty.SeleniumTest.Webmail.Domain
{
	public class User
	{
		public int    id;
		public string name;
		public string password;
		public string fullName;

		public List<Folder> customFolders;

		public User()
		{
			this.customFolders = new List<Folder>();
		}

		public string DisplayName
		{
			get
			{
				return fullName + " (" + name + ")";
			}
		}

	}
}
