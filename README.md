# AuthDemo

This is a simple demo app that shows how to use authentication in .Net Core. When the user tries to access the Secret page, they get redirected to a login page. There's also a signup page at /account/signup.

A few things to look out for:
* When referencing BCrypt in the class library, make sure to reference BCrypt.Net-Next from Nuget

![BCrypt Nuget](https://raw.githubusercontent.com/LITW08/AuthDemo/master/bcrypt.png)

Here are the relevant pieces of code needed to make this work. First, you need to set up Authentication in the `Startup.cs` file:

https://github.com/LITW08/AuthDemo/blob/master/AuthDemo.Web/Startup.cs#L16

https://github.com/LITW08/AuthDemo/blob/master/AuthDemo.Web/Startup.cs#L28-L33

https://github.com/LITW08/AuthDemo/blob/master/AuthDemo.Web/Startup.cs#L52-L53

Then, to actually log a user in, here's the code needed for that:

https://github.com/LITW08/AuthDemo/blob/master/AuthDemo.Web/Controllers/AccountController.cs#L53-L62

To check if a user is logged in, you can use the same `User.Identity.IsAuthenticated` property, and to get the currently logged in users email, you can do `User.Identity.Name`

To log out a user, do the following:

https://github.com/LITW08/AuthDemo/blob/master/AuthDemo.Web/Controllers/AccountController.cs#L69
