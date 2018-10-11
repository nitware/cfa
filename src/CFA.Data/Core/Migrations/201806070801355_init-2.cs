namespace CFA.Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ORDER", "Invoice_No", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ORDER", new[] { "Invoice_No" });
        }
    }
}
