using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTimeHub.Models
{
    public class ServiceType
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Servicetyp")]
        public string Name { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}