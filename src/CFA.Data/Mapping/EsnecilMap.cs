using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class EsnecilMap : EntityTypeConfiguration<Esnecil>
    {
        public EsnecilMap()
        {
            ToTable("ESNECIL");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Esnecil_Id");
            Property(x => x.OrderId).HasColumnName("Order_Id");
            Property(x => x.ProductPriceId).HasColumnName("Product_Price_Id");
            Property(x => x.EsnecilCode).HasColumnName("Esnecil_Code").HasMaxLength(2000);
            Property(x => x.MachineKey).HasColumnName("Machine_Key").HasMaxLength(1500);
            Property(x => x.SerialCode).HasColumnName("Serial_Code").HasMaxLength(2000);
            Property(x => x.EnableTamperChecking).HasColumnName("Enable_Tamper_Checking");
            Property(x => x.DetectDateRollback).HasColumnName("Detect_Date_Rollback");
            Property(x => x.GeneratedOn).HasColumnName("Generated_On");
            Property(x => x.NoOfUsers).HasColumnName("No_Of_Users");
            Property(x => x.RawUserData).HasColumnName("Raw_User_Data").HasMaxLength(2000);

           


        }
    }


}
