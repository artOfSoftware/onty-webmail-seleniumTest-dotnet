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


		public static IWebDriver GetWebDriver()
		{
			string wdt = Properties.Settings.Default.WebDriverType.ToLowerInvariant();

			if ( wdt == "firefox" )
			{
				return GetWebDriver( WebDriverType.Firefox );
			}
			else if ( wdt == "ie" || wdt == "msie" || wdt == "internet explorer" )
			{
				return GetWebDriver( WebDriverType.IE );
			}
			else if ( wdt == "chrome" )
			{
				return GetWebDriver( WebDriverType.Chrome );
			}
			else if ( wdt == "phantomjs" )
			{
				return GetWebDriver( WebDriverType.PhantomJS );
			}
			else
				throw new ArgumentException( "Invalid configuration detected in app.config: WebDriverType is invalid" );
		}


		public static IWebDriver GetWebDriver( WebDriverType driverType )
		{
			IWebDriver d;

			if ( driverType == WebDriverType.PhantomJS )
			{
				d = new PhantomJSDriver();
			}
			else if ( driverType == WebDriverType.Chrome )
			{
				ChromeDriverService svc = ChromeDriverService.CreateDefaultService(  );

				ChromeOptions opt = new ChromeOptions();
				//{
				//	BinaryLocation = ...
				//};

				d = new ChromeDriver( svc, opt, TimeSpan.FromSeconds( 10 ) );
			}
			else if ( driverType == WebDriverType.Firefox )
			{
				FirefoxDriverService svc = FirefoxDriverService.CreateDefaultService(  );

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

				InternetExplorerDriverService svc = InternetExplorerDriverService.CreateDefaultService(  );

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

