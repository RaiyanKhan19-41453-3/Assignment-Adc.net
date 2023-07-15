using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NGO.EF.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [StringLength(100)]
        public string EmpName { get; set; }
        [Required]
        public int EmployeeAge { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<DonationCollection> DonationCollections { get; set; }
        public Employee()
        {
            DonationCollections = new List<DonationCollection>();
        }
    }
}