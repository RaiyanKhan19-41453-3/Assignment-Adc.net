namespace NGO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnPasswordAtEmployeeRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Restaurants", "Password");
        }
    }
}
