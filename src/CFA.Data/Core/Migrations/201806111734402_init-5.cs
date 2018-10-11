namespace CFA.Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Currency", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Status", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Reference", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Domain", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Gateway_Response", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Message", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Channel", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "IP_Address", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Fees", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Last4", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Expiry_Month", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Expiry_Year", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Card_Type", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Bank", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Currency_Code", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Brand", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Signature", c => c.String(maxLength: 50));
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Access_Code", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Access_Code", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Signature", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Brand", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Currency_Code", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Bank", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Card_Type", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Expiry_Year", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Expiry_Month", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Last4", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Fees", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "IP_Address", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Channel", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Message", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Gateway_Response", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Domain", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Reference", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Status", c => c.String());
            AlterColumn("dbo.PAYMENT_PAYSTACK", "Currency", c => c.String());
        }
    }
}
