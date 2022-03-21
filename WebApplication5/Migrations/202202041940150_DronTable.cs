namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DronTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Absolute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drons");
        }
    }
}
