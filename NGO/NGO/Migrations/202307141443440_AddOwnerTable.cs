namespace NGO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Owners");
        }
    }
}
