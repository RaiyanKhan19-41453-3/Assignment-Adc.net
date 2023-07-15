namespace NGO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NGO.EF.NGOContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NGO.EF.NGOContext context)
        {
            /*context.Owners.Add(new EF.Models.Owner()
            {
                OwnerId = 11,
                OwnerName = "Owner"
            });

            context.Restaurants.Add(new EF.Models.Restaurant()
            {
                RestaurantName = "KFC",
                Address = "Khilgaon",
                Password = "123"
            });
            context.Restaurants.Add(new EF.Models.Restaurant()
            {
                RestaurantName = "BFC",
                Address = "Polton",
                Password = "456"
            });*/
        }
    }
}
