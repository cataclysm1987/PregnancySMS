using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PregnancySMS.Models
{
    public class Number
    {
        [Key]
        public string Id { get; set; }
        public int? Weeks { get; set; }
        public bool HasDoctor { get; set; }
        public bool HasInsurance { get; set; }
        public bool HasNutrition { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}