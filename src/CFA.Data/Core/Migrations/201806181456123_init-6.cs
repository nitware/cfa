namespace CFA.Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ORDER", "PaymentPaystack_OrderId", "dbo.PAYMENT_PAYSTACK");
            DropIndex("dbo.ORDER", new[] { "PaymentPaystack_OrderId" });
            AddColumn("dbo.USER", "Phone", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.USER", "Address", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.USER", "Email", c => c.String(nullable: false, maxLength: 320));
            CreateIndex("dbo.ORDER", "Serial_No", unique: true);
            DropColumn("dbo.USER", "Username");
            DropColumn("dbo.ORDER", "PaymentPaystack_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ORDER", "PaymentPaystack_OrderId", c => c.Int());
            AddColumn("dbo.USER", "Username", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.ORDER", new[] { "Serial_No" });
            AlterColumn("dbo.USER", "Email", c => c.String(maxLength: 320));
            DropColumn("dbo.USER", "Address");
            DropColumn("dbo.USER", "Phone");
            CreateIndex("dbo.ORDER", "PaymentPaystack_OrderId");
            AddForeignKey("dbo.ORDER", "PaymentPaystack_OrderId", "dbo.PAYMENT_PAYSTACK", "Order_Id");
        }
    }
}
