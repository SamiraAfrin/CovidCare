using CovidCare.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CovidCare.Controllers
{
    public class UserActivitiesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserActivitiesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //var userId = User.FindFirstValue(ClaimTypes.Name);
            var Logged_in = _db.ApplicationUser.FirstOrDefault(u => u.Id == claim.Value);

             return View(Logged_in);
        }
    }
}
