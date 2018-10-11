namespace CFA.Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USER", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.USER", "Email", unique: true);
            DropColumn("dbo.USER", "Hashed_Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USER", "Hashed_Password", c => c.String(nullable: false));
            DropIndex("dbo.USER", new[] { "Email" });
            DropColumn("dbo.USER", "Password");
        }
    }
}
