using NewsAPI.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsAPI.Models
{
    public class CategoryDTO
    {
        
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public ICollection<NewsDTO> Newses { get; set; } = new List<NewsDTO>();
    }
}