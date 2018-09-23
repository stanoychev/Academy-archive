namespace Sensei.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnedSensors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Sensors", "ApplicationUserId");
            AddForeignKey("dbo.Sensors", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sensors", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Sensors", new[] { "ApplicationUserId" });
            DropColumn("dbo.Sensors", "ApplicationUserId");
        }
    }
}
