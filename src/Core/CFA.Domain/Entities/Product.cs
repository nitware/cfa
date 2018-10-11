using System;
using System.Collections.Generic;

namespace CFA.Domain.Entities
{
    public class Product : BasicEntity
    {
        public int ProductTypeId { get; set; }
        public string Version { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string FilePath { get; set; }
       
        public virtual ProductType ProductType { get; set; }
        public IList<ProductPrice> ProductPrices { get; set; }

    }




}