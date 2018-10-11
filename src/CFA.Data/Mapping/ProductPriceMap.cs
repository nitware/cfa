using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class ProductPriceMap : EntityTypeConfiguration<ProductPrice>
    {
        public ProductPriceMap()
        {
            ToTable("PRODUCT_PRICE");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Product_Price_Id");
            Property(x => x.ProductId).HasColumnName("Product_Id");
            Property(x => x.Price).HasColumnName("Price").HasColumnType("money");
            Property(x => x.CreatedOn).HasColumnName("Created_On");

            HasRequired(p => p.CurrentProductPrice)
                .WithRequiredPrincipal(p => p.ProductPrice);
                

          
        }
    }
}
