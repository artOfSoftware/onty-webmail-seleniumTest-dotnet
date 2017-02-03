using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Onty.SeleniumTest.Webmail.PageObjects
{
	public abstract class APage
	{
		protected IWebDriver driver;

		public APage( IWebDriver driver )
		{
			this.driver = driver;
		}


		protected bool IsDisplayed( By loc, int maxWaitS )
		{
			try
			{
				WebDriverWait wait = new WebDriverWait( this.driver, TimeSpan.FromSeconds(maxWaitS) );
				wait.Until( ExpectedConditions.ElementIsVisible( loc ) );
				return true;
			}
			catch ( WebDriverTimeoutException )
			{
				return false;
			}
		}


	}

}//ns

