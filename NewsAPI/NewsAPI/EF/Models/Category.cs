using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsAPI.EF.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required] 
        public string CategoryName { get; set; }

        public virtual ICollection<News> Newses { get; set; }

        public Category() { 
            Newses = new List<News>();
        }
    }
}