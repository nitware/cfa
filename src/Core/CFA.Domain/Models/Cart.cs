using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;

namespace CFA.Domain.Models
{
    public class Cart
    {
        public Order Order { get; set; }
        public User Customer { get; set; }
        public IList<ProductPrice> ProductPrices { get; set; }
        public DiscountPolicy DiscountPolicy { get; set; }

    }
}
