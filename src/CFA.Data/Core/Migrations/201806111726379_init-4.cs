namespace CFA.Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.USER", name: "Role_Id", newName: "RoleId");
            RenameIndex(table: "dbo.USER", name: "IX_Role_Id", newName: "IX_RoleId");
            CreateTable(
                "dbo.PAYMENT_PAYSTACK",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(),
                        Transaction_Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Reference = c.String(),
                        Domain = c.String(),
                        Gateway_Response = c.String(),
                        Message = c.String(),
                        Channel = c.String(),
                        IP_Address = c.String(),
                        Fees = c.String(),
                        Last4 = c.String(),
                        Expiry_Month = c.String(),
                        Expiry_Year = c.String(),
                        Card_Type = c.String(),
                        Bank = c.String(),
                        Currency_Code = c.String(),
                        Brand = c.String(),
                        ReUsable = c.Boolean(nullable: false),
                        Signature = c.String(),
                        Authorization_Url = c.String(),
                        Access_Code = c.String(),
                    })
                .PrimaryKey(t => t.Order_Id)
                .ForeignKey("dbo.ORDER", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            AddColumn("dbo.ORDER", "PaymentPaystack_OrderId", c => c.Int());
            CreateIndex("dbo.ORDER", "PaymentPaystack_OrderId");
            AddForeignKey("dbo.ORDER", "PaymentPaystack_OrderId", "dbo.PAYMENT_PAYSTACK", "Order_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PAYMENT_PAYSTACK", "Order_Id", "dbo.ORDER");
            DropForeignKey("dbo.ORDER", "PaymentPaystack_OrderId", "dbo.PAYMENT_PAYSTACK");
            DropIndex("dbo.ORDER", new[] { "PaymentPaystack_OrderId" });
            DropIndex("dbo.PAYMENT_PAYSTACK", new[] { "Order_Id" });
            DropColumn("dbo.ORDER", "PaymentPaystack_OrderId");
            DropTable("dbo.PAYMENT_PAYSTACK");
            RenameIndex(table: "dbo.USER", name: "IX_RoleId", newName: "IX_Role_Id");
            RenameColumn(table: "dbo.USER", name: "RoleId", newName: "Role_Id");
        }
    }
}
