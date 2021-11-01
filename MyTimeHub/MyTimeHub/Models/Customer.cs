using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTimeHub.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Customer name")]
        public string Name { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}