using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCare.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string NID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string VaccinationStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime PosDate { get; set; }
        //public string PosDate { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

       
        

    }
}
