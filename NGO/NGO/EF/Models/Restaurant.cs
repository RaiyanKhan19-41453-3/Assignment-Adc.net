using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace NGO.EF.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        [StringLength(100)]
        public string RestaurantName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<DonationRequest> DonationsRequests { get; set; }

        public Restaurant()
        {
            DonationsRequests = new List<DonationRequest>();
        }
    }
}