namespace Sensei.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SharedSensors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserSensors",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Sensor_SensorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Sensor_SensorId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .ForeignKey("dbo.Sensors", t => t.Sensor_SensorId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Sensor_SensorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserSensors", "Sensor_SensorId", "dbo.Sensors");
            DropForeignKey("dbo.ApplicationUserSensors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserSensors", new[] { "Sensor_SensorId" });
            DropIndex("dbo.ApplicationUserSensors", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserSensors");
        }
    }
}
