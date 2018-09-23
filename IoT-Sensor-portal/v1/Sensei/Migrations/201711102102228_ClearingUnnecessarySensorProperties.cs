namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClearingUnnecessarySensorProperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sensors", "SensorIdICB");
            DropColumn("dbo.Sensors", "Tag");
            DropColumn("dbo.Sensors", "Url");
            DropColumn("dbo.Sensors", "PollingInterval");
            DropColumn("dbo.Sensors", "MeasurementType");
            DropColumn("dbo.Sensors", "IsNumericValueType");
            DropColumn("dbo.Sensors", "OperatingRange");
            DropColumn("dbo.Sensors", "UserName");
            DropColumn("dbo.Sensors", "LastUpdate");
            DropColumn("dbo.Sensors", "LastValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sensors", "LastValue", c => c.String());
            AddColumn("dbo.Sensors", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.Sensors", "UserName", c => c.String());
            AddColumn("dbo.Sensors", "OperatingRange", c => c.String());
            AddColumn("dbo.Sensors", "IsNumericValueType", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sensors", "MeasurementType", c => c.String());
            AddColumn("dbo.Sensors", "PollingInterval", c => c.Int(nullable: false));
            AddColumn("dbo.Sensors", "Url", c => c.String());
            AddColumn("dbo.Sensors", "Tag", c => c.String());
            AddColumn("dbo.Sensors", "SensorIdICB", c => c.String());
        }
    }
}
