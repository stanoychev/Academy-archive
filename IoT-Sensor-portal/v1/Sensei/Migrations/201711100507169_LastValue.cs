namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "LastValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "LastValue");
        }
    }
}
