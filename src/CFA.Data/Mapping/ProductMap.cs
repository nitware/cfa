using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("PRODUCT");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Product_Id");
            Property(x => x.ProductTypeId).HasColumnName("Product_Type_Id");
            Property(x => x.Name).HasColumnName("Product_Name").HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Product_Description").HasMaxLength(350);
            Property(x => x.ReleaseDate).HasColumnName("Release_Date");
            Property(x => x.Version).HasColumnName("Version").HasMaxLength(150);
            Property(x => x.FilePath).HasColumnName("File_Path").HasMaxLength(2500);
            
        }
    }



}
