using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using CFA.Data.Core;
using Effort;
using Effort.Provider;
using CFA.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CFA.Test;
using CFA.Data.Setup;
using CFA.Service.Interfaces;

namespace CFA.Data.Test
{
    public class DbContextTest
    {
        private IRepository _db;

        public DbContextTest()
        {
            CFAContext context = Db.GetContext();
            _db = new Repository(context);
        }

        [Fact]
        public void Should_SeedData_WhenDbContextIsInitialised()
        {
            //// Arrange
            //var context = Db.GetContext();
            //Repository db = new Repository(context);

            // Act
            int productTypeCount = _db.GetAll<ProductType>().Count();
            int controllerCount = _db.GetAll<Controller>().Count();

            // Assert
            Assert.Equal(4, productTypeCount);
            Assert.Equal(5, controllerCount);
        }

        [Fact]
        public void Should_CreateProductType_WhenNewProductTypeIsSet()
        {
            ProductType productType = new ProductType()
            {
                Name = "Test 1",
                Description = "Test 1 description"
            };

            _db.Add(productType);
            _db.Save();

            Assert.Equal(5, _db.GetAll<ProductType>().Count());
            Assert.Equal(5, productType.Id);
        }











    }



}
