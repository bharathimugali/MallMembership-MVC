using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MallMembership.Entities
{
   public class AddressInfo
    {
        public int AddressId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }

        public int ApplicantId { get; set; }

    }
}
