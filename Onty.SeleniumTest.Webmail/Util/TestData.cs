using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.Util
{

	public static class TestData
	{

		public static List<User> UsersValid;
		public static List<User> UsersInvalid;



		static TestData()
		{
			UsersValid = new List<User>();
			UsersInvalid = new List<User>();

			// valid users
			UsersValid.Add( new User()
			{
				id =23,
				name ="testuser",
				password ="testuser",
				fullName = "Test User",
			} );

			UsersValid.Add( new User()
			{
				id = 22,
				name = "onty",
				password = "onty",
				fullName = "onty toom",
			} );

			// invalid users
			UsersInvalid.Add( new User()
			{
				id =-1,
				name ="invaliduser",
				password ="unknown",
				fullName = "Nonexistent User for negative testing",
			} );

		}



	}

}//ns

