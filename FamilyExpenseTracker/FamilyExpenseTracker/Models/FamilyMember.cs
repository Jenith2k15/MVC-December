using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyExpenseTracker.Models
{
    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cell is required")]
        [RegularExpression(@"^\d{10}$",ErrorMessage = "A mobile number with 10 digit is rquired")]
        public long Cell { get; set; }
        [Required(ErrorMessage = "Work is required")]
        public string Work { get; set; }
        [Required(ErrorMessage = "Income is required")]
        [Range(10000,200000,ErrorMessage = "Income is Required. It must be between 10000-200000")]
        public int Income { get; set; }
    }
}