namespace Sensei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryProperiesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Histories", "From", c => c.DateTime());
            AddColumn("dbo.Histories", "To", c => c.DateTime());
            AddColumn("dbo.Histories", "Value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Histories", "Value");
            DropColumn("dbo.Histories", "To");
            DropColumn("dbo.Histories", "From");
        }
    }
}
