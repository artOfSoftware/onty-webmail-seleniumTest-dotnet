using System;
using System.Threading;

using NUnit.Framework;

using Onty.SeleniumTest.Webmail.PageObjects;
using Onty.SeleniumTest.Webmail.Util;
using Onty.SeleniumTest.Webmail.Domain;


namespace Onty.SeleniumTest.Webmail.Tests
{

	[TestFixture]
	public class Tests_General : ATest
	{

		[Test]
		public void Test_General_Menu()
		{
			User user = TestData.UsersValid[0];

			// login
			var loginPage = AccountsLoginPage.Go(driver);
			var homePage = loginPage.LoginAsValid( user );

			// check the menu
			Assert.IsTrue( loginPage.CheckMenu(user), "validation of menu failed" );
		}


	}

}//ns
