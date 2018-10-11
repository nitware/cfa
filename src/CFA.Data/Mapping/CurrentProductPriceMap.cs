using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class CurrentProductPriceMap : EntityTypeConfiguration<CurrentProductPrice>
    {
        public CurrentProductPriceMap()
        {
            ToTable("CURRENT_PRODUCT_PRICE");
            HasKey(x => x.ProductPriceId);
            Property(x => x.ProductPriceId).HasColumnName("Product_Price_Id");
         
        }
    }



}
