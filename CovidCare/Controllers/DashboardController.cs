using CovidCare.Data;
using CovidCare.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Configuration;



namespace CovidCare.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        


        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult UseDirection()
        {
            return View();
        }

        public IActionResult VaccineInfo()
        {
            return View();
        }

        public IActionResult EmergencyInfo()
        {
            return View();
        }
        

        public IActionResult OtherInfo()
        {
            return View();
        }
        public IActionResult GeneralGuidelines()
        {
            return View();
        }

        public IActionResult GoogleMap()
        {


           return View();


        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        




    }
}
