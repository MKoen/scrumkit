namespace ScrumKit.Poker.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateDeletedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "DateDeleted", c => c.DateTime());
            AlterColumn("dbo.Users", "DateDeleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateDeleted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rooms", "DateDeleted", c => c.DateTime(nullable: false));
        }
    }
}
