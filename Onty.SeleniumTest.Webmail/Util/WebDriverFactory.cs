using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace Onty.SeleniumTest.Webmail.Util
{

	public class WebDriverFactory
	{

		private static IWebDriver driver;

		public static IWebDriver GetWebDriver( WebDriverType driverType )
		{
			IWebDriver d;

			if ( driverType == WebDriverType.PhantomJS )
			{
				d = new PhantomJSDriver();
			}
			else if ( driverType == WebDriverType.Chrome )
			{
				ChromeDriverService svc = ChromeDriverService.CreateDefaultService(  ); //@"C:\dvt\Selenium\WebDrivers"

				ChromeOptions opt = new ChromeOptions();
				//{
				//BinaryLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe"
				//};
				d = new ChromeDriver( svc, opt, TimeSpan.FromSeconds( 10 ) );
			}
			else if ( driverType == WebDriverType.Firefox )
			{
				FirefoxDriverService svc = FirefoxDriverService.CreateDefaultService(  );   //@"C:\dvt\Selenium\WebDrivers"

				FirefoxOptions opt = new FirefoxOptions()
				{
					BrowserExecutableLocation = Properties.Settings.Default.PathFirefox,
					//@"C:\Program Files\Mozilla Firefox\firefox.exe"
				};
				d = new FirefoxDriver( svc, opt, TimeSpan.FromSeconds( 10 ) );
			}
			else if ( driverType == WebDriverType.IE )
			{
				//DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
				//capabilities.SetCapability( CapabilityType.BrowserName, "IE" );
				//capabilities.SetCapability( CapabilityType.Version, "11" );

				//capabilities.SetCapability( InternetExplorerDriver.INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS, true );
				//capabilities.SetCapability( InternetExplorerDriver.IE_ENSURE_CLEAN_SESSION, true );
				//System.setProperty( "webdriver.ie.driver", "C://MavenTest//driver//IEDriverServer.exe" );
				//driver = new InternetExplorerDriver();

				InternetExplorerOptions opt = new InternetExplorerOptions()
				{
					RequireWindowFocus = false
				};

				InternetExplorerDriverService svc = InternetExplorerDriverService.CreateDefaultService(  );     //@"C:\dvt\Selenium\WebDrivers"

				d = new InternetExplorerDriver( svc, opt, TimeSpan.FromSeconds( 10 ) );
			}
			else
				throw new ArgumentException( "Unknown driver requested" );


			WebDriverFactory.driver = d;

			return d;
		}


		public static void Teardown()
		{
			if ( driver != null )
				driver.Quit();
		}

	}


	public enum WebDriverType
	{
		PhantomJS,
		Chrome,
		Firefox,
		IE,
		Safari,
		Opera,
	}

}//ns

