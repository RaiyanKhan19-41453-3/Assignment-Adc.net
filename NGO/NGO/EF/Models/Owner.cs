using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGO.EF.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        [Required]
        [StringLength(50)]
        public string OwnerName { get; set; }
    }
}