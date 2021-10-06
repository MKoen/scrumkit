namespace ScrumKit.Poker.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoomAndUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        DateDeleted = c.DateTime(nullable: false),
                        UserDeleted = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RoomId = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        DateDeleted = c.DateTime(nullable: false),
                        UserDeleted = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Users", new[] { "RoomId" });
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
        }
    }
}
