namespace NGO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDonationCollectionTableFkRestaurantEmployeePkModifiedEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonationCollections",
                c => new
                    {
                        DonationCollectionId = c.Int(nullable: false, identity: true),
                        DonationId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CollectionTime = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DonationCollectionId)
                .ForeignKey("dbo.DonationRequests", t => t.DonationId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.DonationId)
                .Index(t => t.EmployeeId);
            
            AddColumn("dbo.DonationRequests", "Status", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Status", c => c.String(nullable: false));
            DropForeignKey("dbo.DonationCollections", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DonationCollections", "DonationId", "dbo.DonationRequests");
            DropIndex("dbo.DonationCollections", new[] { "EmployeeId" });
            DropIndex("dbo.DonationCollections", new[] { "DonationId" });
            DropColumn("dbo.DonationRequests", "Status");
            DropTable("dbo.DonationCollections");
        }
    }
}
