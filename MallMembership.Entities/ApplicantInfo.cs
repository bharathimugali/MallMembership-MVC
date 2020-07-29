using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MallMembership.Entities
{
   public class ApplicantInfo : IValidatableObject
    {
        public int ApplicantId { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage = "Please Enter valid name.")]
        [Required(ErrorMessage ="Please enter Firstname")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage = "Please Enter valid name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Enter 10 digits.")]
        [MaxLength(10, ErrorMessage = "Enter 10 digits.")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int HighestCompletedStage { get; set; }

        public string UserAgent { get; set; }
        public string IPAddress { get; set; }
        public string ContentType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var property = new[] { "FirstName" };
            if(FirstName=="aa")
            {
                yield return new ValidationResult("Please Enter valid name",property);
            }
         }
    }
}
