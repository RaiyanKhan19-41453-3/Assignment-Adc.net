using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsAPI.EF.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [Required] 
        public string NewsName { get; set; }
        [Required]
        public string NewsDescription { get; set;}
        [Required]
        public DateTime NewsDate { get; set;}
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}