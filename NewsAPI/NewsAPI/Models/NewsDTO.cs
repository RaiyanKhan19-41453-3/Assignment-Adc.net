using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsAPI.Models
{
    public class NewsDTO
    {
        
        public int NewsId { get; set; }
        
        public string NewsName { get; set; }
        
        public string NewsDescription { get; set; }
        
        public DateTime NewsDate { get; set; }
        
        public int CategoryId { get; set; }

        
    }
}