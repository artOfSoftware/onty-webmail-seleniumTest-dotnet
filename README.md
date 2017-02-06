# Onty.SeleniumTest.Webmail
Automated Selenium test suite for the [Simple Webmail System](https://github.com/ontytoom/onty-webmail-ruby)

These tests were written in C# using Selenuium 3 API. They currently use the Firefox WebDriver, but this is configurable.

## Running the suite

### Pre-requisites

1. MS Windows machine (7 or higher; I run on 64-bit; not tested on 32-bit so may have issues)
1. Visual Studio 2015 or higher (Community version is sufficient)
1. Mozilla FireFox ([version 48](https://ftp.mozilla.org/pub/firefox/releases/48.0.2/)
   is preferred because higher versions of FireFox cause a crash at the end of each test)

### Setup

1. Download the entire suite, and open in Visual Studio
1. Edit the ``app.config`` file and change the ``PathFirefox`` entry to the actual
   path where FireFox is on your machine.
1. In ``Solution Explorer`` tool window, right-click the project ("Onty.SeleniumTest.Webmail" 
   root entry) and click ``Restore NuGet Packages``. This will download all required
   components and place them in appropriate locations to enable the test to run.

### Actually running
1. Open ``Test Expolrer`` tool window in Visual Studio, and click ``Run All``

NOTE: _Occasionally, a message that a FireFox plus has crashed may be displayed.
This does not seem to affect the test results. I don't know how to make the message
not appear.  If anyone knows, please let me know. Thanks._

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
   1. Check presense of all expected menu items in left-hand-side menu (this test really belongs to another category, but not sure where yet)
1. Mailbox
   1. Mailbox page
   1. Create custom folder
   1. Send a message and verify it was sent; also logs in as recipient and verified message was received
   
   
## To do

The following tests still need to be written:

1. Changing the Password
   1. Actually change the password, logout, and try to login using new password
   1. Try changing to blank password (negative test)
   1. Try entering mismatching passwords when changing password (negative test)
1. Create a new account, and try to login
   1. Try to create a new account with duplicate username (negative test)
   1. Try to create a new account with duplicate email, same as an already existing account (negative test)

