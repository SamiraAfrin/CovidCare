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
        [Display(Name = " National Id Card:")]
        public string NID { get; set; }
        [Required(ErrorMessage = "Required")]

        [Display(Name = " Full Name:")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Required")]

        [Display(Name = "Gender:")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth:")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Vaccination Status:")]
        public string VaccinationStatus { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Positive Date:")]
        public DateTime PosDate { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Address:")]
        public string Address { get; set; }
        [Display(Name = "Description:")]
        public string Description { get; set; }

       
        

    }
}
