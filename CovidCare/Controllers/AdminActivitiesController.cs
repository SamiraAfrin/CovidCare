using CovidCare.Data;
using CovidCare.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCare.Controllers
{
    public class AdminActivitiesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AdminActivitiesController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> objList = _db.ApplicationUser;
            return View(objList);
        }
    }
}
