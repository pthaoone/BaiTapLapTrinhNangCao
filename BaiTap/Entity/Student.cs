using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiTap.Entity
{
    // include properties: stuID, name, midPoint, finalPoint, email
    public class Student
    {
        [Required(ErrorMessage = "Student ID is required")]
        public string StuID { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        [RegularExpression(@"^\p{Lu}\p{L}+(?: \p{Lu}\p{L}+$")]
        public string Name { get; set; }
        [Range(0, 10, ErrorMessage = "MidPoint must be between 0 and 10")]
        public double MidPoint { get; set; }
        [Range(0, 10, ErrorMessage = "FinalPoint must be between 0 and 10")]
        public double FinalPoint { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public double getSubjectPoint () => Math.Round((MidPoint + FinalPoint) / 2, 2);
    }
}
