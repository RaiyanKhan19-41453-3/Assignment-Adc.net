using NGO.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NGO.EF
{
    public class NGOContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<DonationCollection> DonationCollections { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}