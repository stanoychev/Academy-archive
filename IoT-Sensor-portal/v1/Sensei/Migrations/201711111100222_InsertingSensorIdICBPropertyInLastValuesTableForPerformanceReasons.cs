namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertingSensorIdICBPropertyInLastValuesTableForPerformanceReasons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LastValues", "SensorIdICB", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LastValues", "SensorIdICB");
        }
    }
}
