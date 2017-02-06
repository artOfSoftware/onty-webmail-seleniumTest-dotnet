# Onty.SeleniumTest.Webmail
Automated Selenium test suite for the [Simple Webmail System](https://github.com/ontytoom/onty-webmail-ruby)

These tests were written in C# using Selenuium 3 API. They currently use the Firefox WebDriver, but this is configurable.

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

