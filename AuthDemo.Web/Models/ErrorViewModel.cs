using System;
using AuthDemo.Data;

namespace AuthDemo.Web.Models
{
    public class HomePageViewModel
    {
        public bool IsAuthenticated { get; set; }
        public User CurrentUser { get; set; }
    }
}
