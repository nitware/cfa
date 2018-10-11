using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Domain.Entities
{
    public class CurrentProductPrice
    {
        public int ProductPriceId { get; set; }

        public virtual ProductPrice ProductPrice { get; set; }
    }



}
