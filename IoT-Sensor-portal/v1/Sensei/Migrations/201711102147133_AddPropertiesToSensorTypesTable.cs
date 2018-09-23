namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToSensorTypesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SensorTypes", "SensorIdICB", c => c.String());
            AddColumn("dbo.SensorTypes", "Tag", c => c.String());
            AddColumn("dbo.SensorTypes", "IsNumericValue", c => c.Boolean(nullable: false));
            AddColumn("dbo.SensorTypes", "MinPollingIntervalInSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.SensorTypes", "MeasureType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SensorTypes", "MeasureType");
            DropColumn("dbo.SensorTypes", "MinPollingIntervalInSeconds");
            DropColumn("dbo.SensorTypes", "IsNumericValue");
            DropColumn("dbo.SensorTypes", "Tag");
            DropColumn("dbo.SensorTypes", "SensorIdICB");
        }
    }
}
