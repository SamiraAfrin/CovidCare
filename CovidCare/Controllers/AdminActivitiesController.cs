using CovidCare.Data;
using CovidCare.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CovidCare.Controllers
{
    public class AdminActivitiesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AdminActivitiesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult GetList()
        {

            {
                IEnumerable<ApplicationUser> objList = _db.ApplicationUser;
                return View(objList);
            }
        }

        //GET -EDIT 
        public IActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.ApplicationUser.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var infoToUpdate = await _db.ApplicationUser
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (await TryUpdateModelAsync<ApplicationUser>(infoToUpdate,
                "",
                c => c.NID,
                c => c.FullName,
                c =>c.Email,
                c => c.Gender,
                c => c.Age,
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
                return RedirectToAction("GetList");
            }
            return View(infoToUpdate);
        }


    

            





        //GET -DELETE
        public IActionResult Delete(string? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.ApplicationUser.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost (string? Id)
        {
            var obj = _db.ApplicationUser.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            
            _db.ApplicationUser.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("GetList");
            
        }


    }
    }


