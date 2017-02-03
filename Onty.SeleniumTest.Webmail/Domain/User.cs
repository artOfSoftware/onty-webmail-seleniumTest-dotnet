using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
