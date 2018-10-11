namespace CFA.Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.USER", "Role_Id", "dbo.ROLE");
            DropIndex("dbo.USER", new[] { "Role_Id" });
            AlterColumn("dbo.USER", "Role_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.USER", "Role_Id");
            AddForeignKey("dbo.USER", "Role_Id", "dbo.ROLE", "Role_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USER", "Role_Id", "dbo.ROLE");
            DropIndex("dbo.USER", new[] { "Role_Id" });
            AlterColumn("dbo.USER", "Role_Id", c => c.Int());
            CreateIndex("dbo.USER", "Role_Id");
            AddForeignKey("dbo.USER", "Role_Id", "dbo.ROLE", "Role_Id");
        }
    }



}
