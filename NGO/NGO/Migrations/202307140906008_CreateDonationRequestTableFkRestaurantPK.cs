namespace NGO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDonationRequestTableFkRestaurantPK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonationRequests",
                c => new
                    {
                        DonationId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DonationId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonationRequests", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.DonationRequests", new[] { "RestaurantId" });
            DropTable("dbo.DonationRequests");
        }
    }
}
