namespace CFA.Data.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ACTION",
                c => new
                    {
                        Action_Id = c.Int(nullable: false, identity: true),
                        Action_Name = c.String(nullable: false, maxLength: 50),
                        Action_Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Action_Id);
            
            CreateTable(
                "dbo.CONTROLLER_ACTION",
                c => new
                    {
                        Controller_Action_Id = c.Int(nullable: false, identity: true),
                        Action_Id = c.Int(nullable: false),
                        Controller_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Controller_Action_Id)
                .ForeignKey("dbo.ACTION", t => t.Action_Id, cascadeDelete: true)
                .ForeignKey("dbo.CONTROLLER", t => t.Controller_Id, cascadeDelete: true)
                .Index(t => t.Action_Id)
                .Index(t => t.Controller_Id);
            
            CreateTable(
                "dbo.CONTROLLER",
                c => new
                    {
                        Controller_Id = c.Int(nullable: false, identity: true),
                        Controller_Name = c.String(nullable: false, maxLength: 50),
                        Controller_Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Controller_Id);
            
            CreateTable(
                "dbo.RIGHT",
                c => new
                    {
                        Right_Id = c.Int(nullable: false, identity: true),
                        Controller_Action_Id = c.Int(nullable: false),
                        Right_Name = c.String(nullable: false, maxLength: 50),
                        Right_Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Right_Id)
                .ForeignKey("dbo.CONTROLLER_ACTION", t => t.Controller_Action_Id, cascadeDelete: true)
                .Index(t => t.Controller_Action_Id);
            
            CreateTable(
                "dbo.ROLE",
                c => new
                    {
                        Role_Id = c.Int(nullable: false, identity: true),
                        Role_Name = c.String(nullable: false, maxLength: 50),
                        Role_Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Role_Id);
            
            CreateTable(
                "dbo.CURRENT_PRODUCT_PRICE",
                c => new
                    {
                        Product_Price_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Product_Price_Id)
                .ForeignKey("dbo.PRODUCT_PRICE", t => t.Product_Price_Id)
                .Index(t => t.Product_Price_Id);
            
            CreateTable(
                "dbo.PRODUCT_PRICE",
                c => new
                    {
                        Product_Price_Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Created_On = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Product_Price_Id)
                .ForeignKey("dbo.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.PRODUCT",
                c => new
                    {
                        Product_Id = c.Int(nullable: false, identity: true),
                        Product_Type_Id = c.Int(nullable: false),
                        Version = c.String(maxLength: 150),
                        Release_Date = c.DateTime(nullable: false),
                        File_Path = c.String(maxLength: 2500),
                        Product_Name = c.String(maxLength: 50),
                        Product_Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Product_Id)
                .ForeignKey("dbo.PRODUCT_TYPE", t => t.Product_Type_Id, cascadeDelete: true)
                .Index(t => t.Product_Type_Id);
            
            CreateTable(
                "dbo.PRODUCT_TYPE",
                c => new
                    {
                        Product_Type_Id = c.Int(nullable: false, identity: true),
                        Product_Type_Name = c.String(nullable: false, maxLength: 50),
                        Product_Type_Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Product_Type_Id);
            
            CreateTable(
                "dbo.DOWNLOAD",
                c => new
                    {
                        Download_Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(nullable: false),
                        Downloaded_From = c.String(maxLength: 550),
                        Download_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Download_Id)
                .ForeignKey("dbo.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.PAYMENT_CHANNEL",
                c => new
                    {
                        Payment_Channel_Id = c.Int(nullable: false, identity: true),
                        Payment_Channel_Name = c.String(nullable: false, maxLength: 50),
                        Payment_Channel_Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.Payment_Channel_Id);
            
            CreateTable(
                "dbo.ORDER",
                c => new
                    {
                        Order_Id = c.Int(nullable: false, identity: true),
                        Payment_Channel_Id = c.Int(nullable: false),
                        Ordered_By = c.Int(nullable: false),
                        Order_Date = c.DateTime(nullable: false),
                        Amount_Payable = c.Decimal(nullable: false, storeType: "money"),
                        Serial_No = c.Int(nullable: false),
                        Invoice_No = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Order_Id)
                .ForeignKey("dbo.USER", t => t.Ordered_By, cascadeDelete: true)
                .ForeignKey("dbo.PAYMENT_CHANNEL", t => t.Payment_Channel_Id, cascadeDelete: true)
                .Index(t => t.Payment_Channel_Id)
                .Index(t => t.Ordered_By);
            
            CreateTable(
                "dbo.ESNECIL",
                c => new
                    {
                        Esnecil_Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        Product_Price_Id = c.Int(nullable: false),
                        Esnecil_Code = c.String(maxLength: 2000),
                        Machine_Key = c.String(maxLength: 1500),
                        Enable_Tamper_Checking = c.Boolean(nullable: false),
                        Detect_Date_Rollback = c.Boolean(nullable: false),
                        Serial_Code = c.String(maxLength: 2000),
                        Raw_User_Data = c.String(maxLength: 2000),
                        No_Of_Users = c.Int(nullable: false),
                        Generated_On = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Esnecil_Id)
                .ForeignKey("dbo.PRODUCT_PRICE", t => t.Product_Price_Id, cascadeDelete: true)
                .ForeignKey("dbo.ORDER", t => t.Order_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Price_Id);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 320),
                        Hashed_Password = c.String(nullable: false),
                        Salt = c.String(nullable: false, maxLength: 2000),
                        Is_Locked = c.Boolean(nullable: false),
                        Created_On = c.DateTime(nullable: false),
                        Last_Updated_On = c.DateTime(),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.User_Id)
                .ForeignKey("dbo.ROLE", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.ROLE_RIGHT",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Right_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Right_Id })
                .ForeignKey("dbo.ROLE", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.RIGHT", t => t.Right_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Right_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ORDER", "Payment_Channel_Id", "dbo.PAYMENT_CHANNEL");
            DropForeignKey("dbo.ORDER", "Ordered_By", "dbo.USER");
            DropForeignKey("dbo.USER", "Role_Id", "dbo.ROLE");
            DropForeignKey("dbo.ESNECIL", "Order_Id", "dbo.ORDER");
            DropForeignKey("dbo.ESNECIL", "Product_Price_Id", "dbo.PRODUCT_PRICE");
            DropForeignKey("dbo.DOWNLOAD", "Product_Id", "dbo.PRODUCT");
            DropForeignKey("dbo.PRODUCT", "Product_Type_Id", "dbo.PRODUCT_TYPE");
            DropForeignKey("dbo.PRODUCT_PRICE", "Product_Id", "dbo.PRODUCT");
            DropForeignKey("dbo.CURRENT_PRODUCT_PRICE", "Product_Price_Id", "dbo.PRODUCT_PRICE");
            DropForeignKey("dbo.ROLE_RIGHT", "Right_Id", "dbo.RIGHT");
            DropForeignKey("dbo.ROLE_RIGHT", "Role_Id", "dbo.ROLE");
            DropForeignKey("dbo.RIGHT", "Controller_Action_Id", "dbo.CONTROLLER_ACTION");
            DropForeignKey("dbo.CONTROLLER_ACTION", "Controller_Id", "dbo.CONTROLLER");
            DropForeignKey("dbo.CONTROLLER_ACTION", "Action_Id", "dbo.ACTION");
            DropIndex("dbo.ROLE_RIGHT", new[] { "Right_Id" });
            DropIndex("dbo.ROLE_RIGHT", new[] { "Role_Id" });
            DropIndex("dbo.USER", new[] { "Role_Id" });
            DropIndex("dbo.ESNECIL", new[] { "Product_Price_Id" });
            DropIndex("dbo.ESNECIL", new[] { "Order_Id" });
            DropIndex("dbo.ORDER", new[] { "Ordered_By" });
            DropIndex("dbo.ORDER", new[] { "Payment_Channel_Id" });
            DropIndex("dbo.DOWNLOAD", new[] { "Product_Id" });
            DropIndex("dbo.PRODUCT", new[] { "Product_Type_Id" });
            DropIndex("dbo.PRODUCT_PRICE", new[] { "Product_Id" });
            DropIndex("dbo.CURRENT_PRODUCT_PRICE", new[] { "Product_Price_Id" });
            DropIndex("dbo.RIGHT", new[] { "Controller_Action_Id" });
            DropIndex("dbo.CONTROLLER_ACTION", new[] { "Controller_Id" });
            DropIndex("dbo.CONTROLLER_ACTION", new[] { "Action_Id" });
            DropTable("dbo.ROLE_RIGHT");
            DropTable("dbo.USER");
            DropTable("dbo.ESNECIL");
            DropTable("dbo.ORDER");
            DropTable("dbo.PAYMENT_CHANNEL");
            DropTable("dbo.DOWNLOAD");
            DropTable("dbo.PRODUCT_TYPE");
            DropTable("dbo.PRODUCT");
            DropTable("dbo.PRODUCT_PRICE");
            DropTable("dbo.CURRENT_PRODUCT_PRICE");
            DropTable("dbo.ROLE");
            DropTable("dbo.RIGHT");
            DropTable("dbo.CONTROLLER");
            DropTable("dbo.CONTROLLER_ACTION");
            DropTable("dbo.ACTION");
        }
    }
}
