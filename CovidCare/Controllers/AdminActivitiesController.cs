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

        //GET -EDIT (Have to fix this)
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
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationUser obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationUser.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("GetList");


            }

            return View(obj);
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

