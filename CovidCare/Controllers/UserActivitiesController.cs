using CovidCare.Data;
using CovidCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult ViewProfile()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //var userId = User.FindFirstValue(ClaimTypes.Name);
            var Logged_in = _db.ApplicationUser.FirstOrDefault(u => u.Id == claim.Value);

            return View(Logged_in);
        }




        //GET -EDIT
        public ActionResult Edit()
        {
            string username = User.Identity.Name;

            // Fetch the userprofile
            ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.Equals(username));

            // Construct the viewmodel
            ApplicationUser model = new ApplicationUser();
            model.NID = user.NID;
            model.FullName = user.FullName;
            model.Email = user.Email;
            model.Gender = user.Gender;
            model.Age = user.Age;
            model.VaccinationStatus = user.VaccinationStatus;
            model.PosDate = user.PosDate;
            model.PhoneNumber = user.PhoneNumber;
            model.Address = user.Address;
            model.Description = user.Description;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser userprofile)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                // Get the userprofile
                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.Equals(username));

                // Update fields

                user.NID = userprofile.NID;
                user.FullName = userprofile.FullName;
                user.Email = userprofile.Email;
                user.Gender = userprofile.Gender;
                user.Age = userprofile.Age;
                user.VaccinationStatus = userprofile.VaccinationStatus;
                user.PosDate = userprofile.PosDate;
                user.PhoneNumber = userprofile.PhoneNumber;
                user.Address = userprofile.Address;
                user.Description = userprofile.Description;

                

                _db.Entry(user).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("ViewProfile"); // or whatever
            }

            return RedirectToAction("ViewProfile");
        }

    }
}

