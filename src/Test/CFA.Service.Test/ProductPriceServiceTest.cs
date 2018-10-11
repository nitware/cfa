using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using CFA.Service.Interfaces;
using CFA.Data;
using CFA.Test;
using CFA.Domain.Entities;

namespace CFA.Service.Test
{
    public class ProductPriceServiceTest
    {
        private IRepository _repository;
        private IProductPriceService _productPriceService;

        public ProductPriceServiceTest()
        {
            var dbContext = Db.GetContext();
            _repository = new Repository(dbContext);
            _productPriceService = new ProductPriceService(_repository);

            CreateProduct();
            CreateProduct();
            CreateProduct();
        }

        private void CreateProduct()
        {
            Product product = new Product()
            {
                Version = "1.0",
                ReleaseDate = DateTime.Now,
                Name = "StorePro Standard",
                Description = "Stand alone version for a single system",
                FilePath = "http://storepro.nitware.com.ng/downloads/storepro_standard.exe",
                ProductTypeId = 1,
            };

            _repository.Add<Product>(product);
            _repository.Save();
        }
        private void CreateCurrentProjectPrices()
        {
            CurrentProductPrice currentProductPrice = new CurrentProductPrice();
            ProductPrice productPrice = new ProductPrice() { ProductId = 2, CreatedOn = DateTime.UtcNow, Price = 120000, CurrentProductPrice = currentProductPrice };
            _productPriceService.SetProductPrice(productPrice);

            CurrentProductPrice currentProductPrice2 = new CurrentProductPrice();
            ProductPrice productPrice2 = new ProductPrice() { ProductId = 2, CreatedOn = DateTime.UtcNow, Price = 150000, CurrentProductPrice = currentProductPrice2 };
            _productPriceService.SetProductPrice(productPrice2);

            CurrentProductPrice currentProductPrice3 = new CurrentProductPrice();
            ProductPrice productPrice3 = new ProductPrice() { ProductId = 1, CreatedOn = DateTime.UtcNow, Price = 15000, CurrentProductPrice = currentProductPrice3 };
            _productPriceService.SetProductPrice(productPrice3);
        }
      
        [Fact]
        public void SetProductPrice_Should_SetPriceOfProduct()
        {
            CreateCurrentProjectPrices();

            CurrentProductPrice newCurrentProductPrice3 = _repository.GetSingle<CurrentProductPrice>(3);
            IList<CurrentProductPrice> currentProductPrices = _repository.GetAll<CurrentProductPrice>().ToList();
            IList<ProductPrice> newProductPrices = _repository.GetAll<ProductPrice>().ToList();

            Assert.NotNull(currentProductPrices);
            Assert.NotNull(newCurrentProductPrice3);
            Assert.NotNull(newProductPrices);
            Assert.Equal(2, currentProductPrices.Count);
            Assert.Equal(3, newCurrentProductPrice3.ProductPriceId);
            Assert.Equal(3, newProductPrices.Count);
        }

        [Fact]
        public void GetProductPriceBy_Should_ReurnCurrentPriceOfProduct_IfProductPriceCountIsMoreGreaterOne()
        {
            CreateCurrentProjectPrices();

            ProductPrice newProductPrice = _productPriceService.GetProductPriceBy(2);
            ProductPrice newProductPrice2 = _productPriceService.GetProductPriceBy(new Product() { Id = 1 });

            Assert.NotNull(newProductPrice);
            Assert.NotNull(newProductPrice2);
            Assert.Equal(2, newProductPrice.Id);
            Assert.Equal(150000, newProductPrice.Price);
            Assert.Equal(3, newProductPrice2.Id);
            Assert.Equal(15000, newProductPrice2.Price);
        }



       
    }

}
