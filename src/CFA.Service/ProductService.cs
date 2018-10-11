using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Domain.Models;
using CFA.Service.Interfaces;
using CFA.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace CFA.Service
{
    public class ProductService : IProductService
    {
        private IRepository _repository;

        public ProductService(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public IList<Product> GetAllProduct(params Expression<Func<Product, object>>[] includeProperties)
        {
            return _repository.GetAll<Product>(includeProperties).ToList();
        }

        public Product GetProductBy(int id, params Expression<Func<Product, object>>[] includeProperties)
        {
            Expression<Func<Product, bool>> predicate = x => x.Id == id;
            return _repository.GetSingle<Product>(predicate, includeProperties);
        }

        public OperationResult<Product> ModifyProduct(Product product)
        {
            if (product.IsNull())
            {
                return new OperationResult<Product>(false)
                {
                    Error = new ArgumentNullException("product")
                };
            }
            
            Product existingProduct = _repository.GetSingle<Product>(product.Id);
            if (existingProduct.IsNull())
            {
                return new OperationResult<Product>(false)
                {
                    Error = new KeyNotFoundException("Product with ID '" + product.Id + "' not found!")
                };
            }
             
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.FilePath = product.FilePath;
            existingProduct.ProductTypeId = product.ProductTypeId;
            existingProduct.ReleaseDate = product.ReleaseDate;
            existingProduct.Version = product.Version;
            
            _repository.Update(existingProduct);
            _repository.Save();

            return new OperationResult<Product>(true) { Entity = existingProduct };
        }




    }


}
