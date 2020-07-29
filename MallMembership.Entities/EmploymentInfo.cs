using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MallMembership.Entities
{
   public class EmploymentInfo
    {
        public int EmploymentId { get; set; }
        [Required]
        public string EmploymentType { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int ApplicantId { get; set; }

    }
    public enum EmploymentType
    {
        Employed,
        UnEmployed
    }
}
