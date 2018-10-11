using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Data;
using CFA.Test;
using CFA.Service.Interfaces;
using Xunit;
using CFA.Domain.Entities;
using CFA.Domain.Models;

namespace CFA.Service.Test
{
    public class ProductServiceTest
    {
        private IRepository _repository;
        private IProductService _productService;

        public ProductServiceTest()
        {
            var dbContext = Db.GetContext();
            _repository = new Repository(dbContext);
            _productService = new ProductService(_repository);

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
        private void DeleteProduct(Product product)
        {
            _repository.Delete<Product>(product);
            _repository.Save();
        }

        [Fact]
        public void GetAll_Should_ReturnAllProducts()
        {
            IList<Product> products = _productService.GetAllProduct();

            Assert.NotNull(products);
            Assert.NotNull(products[0].ProductType);
            Assert.Equal(1, products.Count);
        }
        
        [Fact]
        public void GetProductBy_Should_ReturnProduct_WhenProductIDIsSpecified()
        {
            Product product = _productService.GetProductBy(1);

            Assert.NotNull(product);
            Assert.NotNull(product.ProductType);
            Assert.Equal(1, product.Id);
        }

        [Fact]
        public void GetProductBy_Should_ReturnNull_WhenProductIDSpecifiedDoesNotExist()
        {
            Product product = _productService.GetProductBy(2);
            Assert.Null(product);
        }

        [Fact]
        public void ModifyProduct_Should_ReturnModifiedProduct_WhenWellFormedProductIsSpecified()
        {
            Product product = _productService.GetProductBy(1);
            product.Name = "modified";

            OperationResult<Product> result = _productService.ModifyProduct(product);

            Assert.NotNull(result);
            Assert.NotNull(result.Entity);
            Assert.True(result.IsSuccess);
            Assert.Equal("modified", result.Entity.Name);
            Assert.Null(result.Error);
        }

        [Theory]
        [InlineData(2)]
        public void ModifyProduct_Should_ReturnError_WhenProductSpecifiedIsNull(int productId)
        {
            Product product = _productService.GetProductBy(productId);

            OperationResult<Product> result = _productService.ModifyProduct(product);

            Assert.NotNull(result);
            Assert.Null(result.Entity);
            Assert.False(result.IsSuccess);
            Assert.IsType<ArgumentNullException>(result.Error);
            Assert.NotNull(result.Error);
        }

        [Theory]
        [InlineData(1)]
        public void ModifyProduct_Should_ReturnError_WhenProductSpecifiedDoesNotExist(int productId)
        {
            Product product = _productService.GetProductBy(productId);
            DeleteProduct(product);

            OperationResult<Product> result = _productService.ModifyProduct(product);

            Assert.NotNull(result);
            Assert.Null(result.Entity);
            Assert.False(result.IsSuccess);
            Assert.IsType<KeyNotFoundException>(result.Error);
            Assert.NotNull(result.Error);
        }

       




    }
}
