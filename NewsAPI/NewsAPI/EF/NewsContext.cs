using NewsAPI.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewsAPI.EF
{
    public class NewsContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> Newses { get; set; }
    }
}