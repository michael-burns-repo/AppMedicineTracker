using System;
using System.ComponentModel.DataAnnotations;

namespace AppMedicineTracker.Models
{
    public class Medicine 
    {
        public int Id { get; set; }

        [Display(Name = "Medicine")]
        public string Name { get; set; }

        public string Dose { get; set; }

        [Display(Name = "Dosage Form")]
        public string? Form { get; set; }

        [Display(Name = "Taken For")]
        public string? Condition { get; set; }

        [Display(Name = "Prescribed By")]
        public string? PrescribedBy { get; set; }

        public string Frequency { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Days On")]
        public int? DaysOn { get; set; }

        [Display(Name = "Days Off")]
        public int? DaysOff { get; set; }

        public string? Notes { get; set; }

        public string? ImagePath { get; set; }

        public string User { get; set; }

        public int Supply { get; set; }

        public int? Refills {get; set; }

        public string? Instructions { get; set; }

        public bool Suspend { get; set; }
    }
}
