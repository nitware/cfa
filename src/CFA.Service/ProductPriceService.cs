using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Service.Interfaces;
using CFA.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace CFA.Service
{
    public class ProductPriceService : IProductPriceService
    {
        private IRepository _repository;

        public ProductPriceService(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public IList<ProductPrice> GetAllProductPrices()
        {
            return _repository.GetAll<ProductPrice>().ToList();
        }

        public ProductPrice GetProductPriceBy(int id)
        {
            return GetProductPriceByHelper(p => p.ProductPriceId == id);
        }

        public ProductPrice GetProductPriceBy(Product product)
        {
            if (product.IsNull())
            {
                throw new ArgumentNullException("product");
            }

            return GetProductPriceByHelper(p => p.ProductPrice.ProductId == product.Id);
        }

        private ProductPrice GetProductPriceByHelper(Expression<Func<CurrentProductPrice, bool>> selector)
        {
            ProductPrice productPrice = null;
            Expression<Func<CurrentProductPrice, object>> includeProperties = x => x.ProductPrice;
            //Expression<Func<CurrentProductPrice, bool>> selector = p => p.ProductPrice.ProductId == productId;

            CurrentProductPrice currentProductPrice = _repository.GetSingle<CurrentProductPrice>(selector, includeProperties);
            if (currentProductPrice != null && currentProductPrice.ProductPriceId > 0)
            {
                productPrice = currentProductPrice.ProductPrice;
            }

            return productPrice;
        }

        public void SetProductPrice(ProductPrice productPrice)
        {
            if (productPrice == null)
            {
                throw new ArgumentNullException("productPrice");
            }

            if (productPrice.CurrentProductPrice == null)
            {
                throw new ArgumentNullException("Current Product Price not set!");
            }

            IList<ProductPrice> existingProductPrices = _repository.FindBy<ProductPrice>(x => x.ProductId == productPrice.ProductId).ToList();
            if (existingProductPrices.HasItem())
            {
                _repository.Delete<CurrentProductPrice>(x => x.ProductPrice.ProductId == productPrice.ProductId);
            }

            _repository.Add(productPrice);
            _repository.Save();
        }





    }


}
