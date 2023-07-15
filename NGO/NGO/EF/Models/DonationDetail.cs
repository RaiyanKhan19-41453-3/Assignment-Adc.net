using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGO.EF.Models
{
    public class DonationDetail
    {
        [Key] 
        public int Id { get; set; }
    }
}