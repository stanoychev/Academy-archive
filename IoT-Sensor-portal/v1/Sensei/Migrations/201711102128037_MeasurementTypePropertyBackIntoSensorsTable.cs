namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeasurementTypePropertyBackIntoSensorsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "MeasurementType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "MeasurementType");
        }
    }
}
