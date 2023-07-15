using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NGO.EF.Models
{
    public class DonationCollection
    {
        [Key]
        public int DonationCollectionId { get; set; }
        [ForeignKey("DonationRequest")]
        public int DonationId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime CollectionTime { get; set; } = DateTime.Now.Date;
        [Required]
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual DonationRequest DonationRequest { get; set; }
    }
}