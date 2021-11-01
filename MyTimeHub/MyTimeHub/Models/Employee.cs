using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTimeHub.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Vorname")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nachname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Pensum")]
        public int Pensum { get; set; }

        [Display(Name = "Saldo")]
        public int Saldo { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}