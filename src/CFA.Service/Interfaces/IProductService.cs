using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Domain.Models;
using System.Linq.Expressions;

namespace CFA.Service.Interfaces
{
    public interface IProductService
    {
        Product GetProductBy(int id, params Expression<Func<Product, object>>[] includeProperties);
        IList<Product> GetAllProduct(params Expression<Func<Product, object>>[] includeProperties);
        OperationResult<Product> ModifyProduct(Product product);

        //OperationResult<Product> DeleteProduct(Product product);
    }


}
