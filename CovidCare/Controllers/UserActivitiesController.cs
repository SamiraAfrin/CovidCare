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
        public IActionResult Edit()
        {
            string username = User.Identity.Name;

            //Fetch the userprofile
            ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.Equals(username));

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost()
        {
            // Fetch the logged in user id
            string username = User.Identity.Name;

            ////Fetch the userprofile
            ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.Equals(username));

            if (user == null)
            {
                return NotFound();
            }

            var infoToUpdate = await _db.ApplicationUser
                .FirstOrDefaultAsync(c => c.Id == user.Id);

            if (await TryUpdateModelAsync<ApplicationUser>(infoToUpdate,
                "",
                c => c.NID,
                c => c.FullName,
                c => c.Email,
                c => c.Gender,
                c => c.DOB,
                c => c.VaccinationStatus,
                c => c.PosDate,
                c => c.PhoneNumber,
                c => c.Address,
                c => c.Description))
            {
                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("ViewProfile");
            }
            return View(infoToUpdate);
        }

        // //GET - Add Report
        public IActionResult AddReport()
        {   
                string username = User.Identity.Name;

                //Fetch the userprofile
                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.Equals(username));
                if (user == null)
                {
                    return NotFound();
                }
            return View();
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReport(Report Report)
        {
            // Fetch the logged in user id
            string username = User.Identity.Name;

            //Fetch the userprofile
            
            if (ModelState.IsValid)
            {

                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.Equals(username));
                if (user == null)
                {
                    return NotFound();
                }
                Report.Id = user.Id;
                _db.Report.Add(Report);
                _db.SaveChanges();
                return RedirectToAction("ShowReport");
            }
            return View(Report);
        }
        public IActionResult ShowReport()
        {
            // Fetch the logged in user id
            string username = User.Identity.Name;

            ////Fetch the userprofile
            ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.Equals(username));
            if (user == null)
            {
                return NotFound();
            }
            IEnumerable<Report> objList = (_db.Report.Where(c => c.Id == user.Id).OrderByDescending(c => c.Date)).ToList();
            return View(objList);
        }

        


    }
}

