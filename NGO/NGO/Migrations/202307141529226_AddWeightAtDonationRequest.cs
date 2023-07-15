namespace NGO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeightAtDonationRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationRequests", "Weight", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationRequests", "Weight");
        }
    }
}
