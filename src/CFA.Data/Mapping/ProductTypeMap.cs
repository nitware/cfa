using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class ProductTypeMap : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeMap()
        {
            ToTable("PRODUCT_TYPE");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Product_Type_Id");
            Property(x => x.Name).HasColumnName("Product_Type_Name").HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasColumnName("Product_Type_Description").HasMaxLength(350);

        }



    }
}
