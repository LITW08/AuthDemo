using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthDemo.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace AuthDemo.Web.Controllers
{
    public class AccountController : Controller
    {

        private string _connectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=AuthDemo;Integrated Security=true;";

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user, string password)
        {
            var db = new UserDb(_connectionString);
            db.AddUser(user, password);
            return Redirect("/");
        }

        public IActionResult Login()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"];
            }   
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var db = new UserDb(_connectionString);
            var user = db.Login(email, password);
            if (user == null)
            {
                //invalid email/password combo
                TempData["message"] = "Invalid email/password combination";
                return Redirect("/account/login");
            }

            var claims = new List<Claim>
            {
                new Claim("user", email) // this will get set to User.Identity.Name
            };

            //this line of code is the one that actually signs in the user
            //it basically sets a special cookie on the clients machine that
            //sets them as "logged in"
            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();

            return Redirect("/home/secret");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return Redirect("/");
        }
        
    }
}
