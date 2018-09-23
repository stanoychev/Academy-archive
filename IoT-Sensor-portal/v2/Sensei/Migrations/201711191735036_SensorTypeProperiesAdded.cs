namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SensorTypeProperiesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SensorTypes", "SensorIdICB", c => c.String());
            AddColumn("dbo.SensorTypes", "Tag", c => c.String());
            AddColumn("dbo.SensorTypes", "Description", c => c.String());
            AddColumn("dbo.SensorTypes", "MinPollingIntervalInSeconds", c => c.Int(nullable: false));
            AddColumn("dbo.SensorTypes", "MeasureType", c => c.String());
            AddColumn("dbo.SensorTypes", "IsNumericValue", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SensorTypes", "IsNumericValue");
            DropColumn("dbo.SensorTypes", "MeasureType");
            DropColumn("dbo.SensorTypes", "MinPollingIntervalInSeconds");
            DropColumn("dbo.SensorTypes", "Description");
            DropColumn("dbo.SensorTypes", "Tag");
            DropColumn("dbo.SensorTypes", "SensorIdICB");
        }
    }
}
