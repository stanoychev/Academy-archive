namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastValueProperiesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LastValues", "SensorIdICB", c => c.String());
            AddColumn("dbo.LastValues", "PollingInterval", c => c.Int(nullable: false));
            AddColumn("dbo.LastValues", "Value", c => c.String());
            AddColumn("dbo.LastValues", "From", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LastValues", "From");
            DropColumn("dbo.LastValues", "Value");
            DropColumn("dbo.LastValues", "PollingInterval");
            DropColumn("dbo.LastValues", "SensorIdICB");
        }
    }
}
