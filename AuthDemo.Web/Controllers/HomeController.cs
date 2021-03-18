using AuthDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthDemo.Data;
using Microsoft.AspNetCore.Authorization;

namespace AuthDemo.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private string _connectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=AuthDemo;Integrated Security=true;";

        //[AllowAnonymous]
        public IActionResult Index()
        {
            var vm = new HomePageViewModel
            {
                IsAuthenticated = User.Identity.IsAuthenticated
            };
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name; //this will be equal to what you put into the Claims list when logging in the user
                var db = new UserDb(_connectionString);
                vm.CurrentUser = db.GetByEmail(email);
            }
            return View(vm);
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

    }
}
