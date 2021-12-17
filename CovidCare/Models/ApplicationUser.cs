using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCare.Models
{
    public class ApplicationUser : IdentityUser
    {   [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "This field must be 17 characters")]
        public string NID { get; set; }
        [Required(ErrorMessage = "Required")] 
        public string FullName { get; set; }
        [Required(ErrorMessage = "Required")] 
        public string Gender { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Required")]
        public string VaccinationStatus { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime PosDate { get; set; }
        
        [Required(ErrorMessage = "Required")] 
        public string Address { get; set; }
        public string Description { get; set; }

       
        

    }
}
