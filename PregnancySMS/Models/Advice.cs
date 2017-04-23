using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PregnancySMS.Models
{
    public class Advice
    {
        [Key]
        public int Id { get; set; }
        public int Trimester { get; set; }
        public string AdviceText { get; set; }

    }
}