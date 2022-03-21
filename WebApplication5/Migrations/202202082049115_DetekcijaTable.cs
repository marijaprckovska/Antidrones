namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetekcijaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detekcijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DronId = c.Int(nullable: false),
                        SensorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Detekcijas");
        }
    }
}
