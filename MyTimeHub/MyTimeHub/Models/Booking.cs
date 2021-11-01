using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTimeHub.Models
{
    public class Booking
    {
        public int ID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }


        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "Service Type ID")]
        public int ServiceTypeID { get; set; }


        [Display(Name = "Employee")]
        public virtual Employee Employee { get; set; }

        [Display(Name = "Customer")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "ServiceType")]
        public virtual ServiceType ServiceType { get; set; }

    }
}