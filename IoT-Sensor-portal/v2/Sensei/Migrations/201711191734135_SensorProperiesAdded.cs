namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SensorProperiesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "UserDefinedSensorName", c => c.String());
            AddColumn("dbo.Sensors", "UserDefinedDescription", c => c.String());
            AddColumn("dbo.Sensors", "UserDefinedMeasureType", c => c.String());
            AddColumn("dbo.Sensors", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sensors", "UserDefinedMinValue", c => c.Double(nullable: false));
            AddColumn("dbo.Sensors", "UserDefinedMaxValue", c => c.Double(nullable: false));
            AddColumn("dbo.Sensors", "AddedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "AddedOn");
            DropColumn("dbo.Sensors", "UserDefinedMaxValue");
            DropColumn("dbo.Sensors", "UserDefinedMinValue");
            DropColumn("dbo.Sensors", "IsPublic");
            DropColumn("dbo.Sensors", "UserDefinedMeasureType");
            DropColumn("dbo.Sensors", "UserDefinedDescription");
            DropColumn("dbo.Sensors", "UserDefinedSensorName");
        }
    }
}
