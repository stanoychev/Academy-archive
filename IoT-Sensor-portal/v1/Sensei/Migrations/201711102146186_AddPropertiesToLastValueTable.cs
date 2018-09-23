namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToLastValueTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LastValues", "PollingInterval", c => c.Int(nullable: false));
            AddColumn("dbo.LastValues", "Value", c => c.String());
            AddColumn("dbo.LastValues", "LastUpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LastValues", "LastUpdatedOn");
            DropColumn("dbo.LastValues", "Value");
            DropColumn("dbo.LastValues", "PollingInterval");
        }
    }
}
