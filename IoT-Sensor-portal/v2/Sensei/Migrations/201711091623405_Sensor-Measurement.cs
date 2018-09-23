namespace Sensei.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SensorMeasurement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measurements", "SensorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Measurements", "SensorId");
            AddForeignKey("dbo.Measurements", "SensorId", "dbo.Sensors", "SensorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Measurements", "SensorId", "dbo.Sensors");
            DropIndex("dbo.Measurements", new[] { "SensorId" });
            DropColumn("dbo.Measurements", "SensorId");
        }
    }
}
