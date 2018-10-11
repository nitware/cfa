using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;

namespace CFA.Service.Interfaces
{
    public interface IProductPriceService
    {
        void SetProductPrice(ProductPrice productPrice);
        ProductPrice GetProductPriceBy(Product product);
        ProductPrice GetProductPriceBy(int id);
        IList<ProductPrice> GetAllProductPrices();
    }






}
