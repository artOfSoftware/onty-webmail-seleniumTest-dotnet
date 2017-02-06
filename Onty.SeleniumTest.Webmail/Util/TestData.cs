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
				id       = 2,
				name     = "testuser",
				password = "testuser",
				fullName = "test user",
			} );

			UsersValid.Add( new User()
			{
				id       = 3,
				name     = "testuser2",
				password = "testuser2",
				fullName = "test user 2",
			} );

			// invalid users
			UsersInvalid.Add( new User()
			{
				id       = -1,
				name     = "invaliduser",
				password = "unknown",
				fullName = "Nonexistent User for negative testing",
			} );

		}



	}

}//ns

