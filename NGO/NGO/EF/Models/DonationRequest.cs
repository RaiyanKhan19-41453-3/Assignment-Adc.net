using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NGO.EF.Models
{
    public class DonationRequest
    {
        [Key]
        public int DonationId { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        [Required]
        public DateTime RequestTime { get; set; } = DateTime.Now.Date;
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string Status { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<DonationCollection> DonationCollections { get; set; }
        public DonationRequest()
        {
            DonationCollections = new List<DonationCollection>();
        }
    }
}