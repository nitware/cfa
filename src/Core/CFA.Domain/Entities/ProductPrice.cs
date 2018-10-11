using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Interfaces;

namespace CFA.Domain.Entities
{
    public class ProductPrice : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
                
        public CurrentProductPrice CurrentProductPrice { get; set; }
        public Product Product { get; set; }

    }


}
