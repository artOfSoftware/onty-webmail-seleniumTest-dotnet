# Onty.SeleniumTest.Webmail

Automated Selenium test suite for the 
[Simple Webmail System](https://github.com/ontytoom/onty-webmail-ruby)

These tests were written in C# using Selenuium 3 API. 
They currently support FireFox, IE, Chrome, and PhantomJS.


## Running the suite

### Pre-requisites

1. **Microsoft Windows machine**
   _(7 or higher; I run on 64-bit; not tested on 32-bit so may have issues)_
1. **Microsoft Visual Studio 2015** or higher
   _([Community version](https://www.visualstudio.com/vs/community/)
   is sufficient)_
1. **Microsoft .NET 4.6.2 Developer Pack**
   _([download here](http://getdotnet.azurewebsites.net/target-dotnet-platforms.html);
   you will need to restart the machine afterwards)_
1. A supported web browser. Suite currently supports:
   1. **Mozilla FireFox** _([version 48](https://ftp.mozilla.org/pub/firefox/releases/48.0.2/)
      is strongly suggested because higher versions of FireFox cause a crash 
      at the end of each test.)_
   1. **Microsoft Internet Explorer** _(I use version 11 on 64-bit Windows 7 machine; if you use anything
      else your mileage may vary. Also please make sure you follow the required setup instructions 
      in Setup section below.)_
      _([Read here](http://jimevansmusic.blogspot.com/2014/09/screenshots-sendkeys-and-sixty-four.html)
      for a detailed discussion on why you should use 32-bit IE WebDriver instead of 64-bit.)_
   1. **Google Chrome**
   1. **PhantomJS** - a "headless" browser

### Setup

1. Download the entire suite, and open in Visual Studio
1. In ``Solution Explorer`` tool window, right-click the solution
   ("Onty.SeleniumTest.Webmail" root entry) and click ``Restore NuGet Packages``. 
   This will download all required components and place them in 
   appropriate locations to enable the test to run.
1. Browser configuration:
   1. All browsers: edit the ``app.config`` file, and change ``WebDriverType`` to:
      ``firefox`` to run tests using Firefox, or ``ie`` for Internet Explorer, 
      or ``chrome`` for Chrome, or ``phantomjs`` for PhantomJS
   1. FireFox: Edit the ``app.config`` file and change the ``PathFirefox`` 
      entry to the actual path where FireFox is on your machine.
   1. MSIE: Please please please make sure you follow
      [the setup instructions](https://github.com/SeleniumHQ/selenium/wiki/InternetExplorerDriver#required-configuration)


### Actually running

1. Open ``Test Expolrer`` tool window in Visual Studio, and click ``Run All``

#### Notes:
 
1. _Occasionally, a message that a FireFox plugin has crashed may be displayed.
   This does not seem to affect the test results. Just click "close" after the test
   finisies running. I don't know how to make the message not appear.
   If anyone knows how to fix it, please tell me. Thanks._
1. _The WebDriver executables sometimes stay running in memory after the test completes.
   This is a deficiency of WebDriver. The test calls driver.Quit() whether test passes
   or fails, but every now and again you may find leftover processes._


## Implemented tests

1. Unauthenticated user
   1. Login page
1. Login
   1. Valid login
   1. Invalid login
1. Account pages
   1. View user list, and view info for currently logged in user
   1. Password page
   1. Logout
   1. Create a new account
1. Mailbox
   1. Mailbox page
   1. Create custom folder
   1. Send a message and verify it was sent; also logs in as recipient and 
      verifies that message was received
1. General tests
   1. Check presense of all expected menu items in left-hand-side menu 
      (this test really belongs to another category, but not sure where yet)

   
## To do

### The following tests still need to be written

1. Changing the Password
   1. Actually change the password, logout, and try to login using new password
   1. Try changing to blank password (negative test)
   1. Try entering mismatching passwords when changing password (negative test)
1. Negative tests for creating a new account
   1. Try to create a new account with duplicate username (negative test)
   1. Try to create a new account with duplicate email, same as an already existing account (negative test)

### General to-do items

1. Get suite to run on other browsers
   1. Safari
1. Currently every time a new page is retrieved, 
   the function CommonPageElements.WaitForPageToLoad() is called.
   The latter is currently implemented as a simple Thread.Sleep()
   which works, but is a bad idea in the long-term. 
   There need to be a better way to determine if a page has loaded.
   For example, there could be some hidden element at the end of the page
   presense of which can be used to determine if page has fully loaded.
   If you are reading this, and know a good way to do so, please contact me
   and educate me.

