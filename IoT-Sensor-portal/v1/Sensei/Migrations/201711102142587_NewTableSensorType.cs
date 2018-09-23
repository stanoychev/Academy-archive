namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableSensorType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SensorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sensors", "SensorType_Id", c => c.Int());
            CreateIndex("dbo.Sensors", "SensorType_Id");
            AddForeignKey("dbo.Sensors", "SensorType_Id", "dbo.SensorTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sensors", "SensorType_Id", "dbo.SensorTypes");
            DropIndex("dbo.Sensors", new[] { "SensorType_Id" });
            DropColumn("dbo.Sensors", "SensorType_Id");
            DropTable("dbo.SensorTypes");
        }
    }
}
