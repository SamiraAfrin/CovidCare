using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCare.Models
{
    public class Report
    {   
        [Key]
        public int ReportId { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Date:")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Body Temperature is required")]
        [Display(Name = "Body Temperature:")]
        public double BoTep { get; set; } // Body Temperature

        [Required(ErrorMessage = "Oximeter reading is required")]
        [Display(Name = "Oximeter Reading:")]
        public double OR{ get; set; } // Oximeter Reading

        [Display(Name = "High Blood Pressure :")]
        public double BP_high { get; set; } // Blood Pressure
        [Display(Name = " Low Blood Pressure:")]
        public double BP_low { get; set; } // Blood Pressure

        [Display(Name = "Sugar Level:")]
        public double SL { get; set; } // Sugar level 

        [Display(Name = "Description:")]
        public string  Description { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
