namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLastValuesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LastValues",
                c => new
                    {
                        SensorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SensorId)
                .ForeignKey("dbo.Sensors", t => t.SensorId)
                .Index(t => t.SensorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LastValues", "SensorId", "dbo.Sensors");
            DropIndex("dbo.LastValues", new[] { "SensorId" });
            DropTable("dbo.LastValues");
        }
    }
}
