using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Service.Interfaces;
using CFA.Test;
using CFA.Data;
using CFA.Generator;
using CFA.Generator.Interfaces;
using CFA.Domain.Models;
using CFA.Domain.Entities;
using Xunit;

namespace CFA.Service.Test
{
    public class OrderServiceTest
    {
        private IRepository _repository;
        private IOrderService _orderService;
        private EsnecilGeneratorBase _esnecilGenerator;
        private IProductPriceService _productPriceService;
        private IInvoiceManager _invoiceManager;

        public OrderServiceTest()
        {
            IEsnecilGeneratorResource esnecilGeneratorFile = new EsnecilGeneratorFile();

            var dbContext = Db.GetContext();
            _repository = new Repository(dbContext);
            _invoiceManager = new InvoiceManager(_repository);
            _esnecilGenerator = new TrialEsnecilGenerator(esnecilGeneratorFile);
            
            _orderService = new OrderService(_repository, _invoiceManager, _esnecilGenerator);
            _productPriceService = new ProductPriceService(_repository);

            //CreateOrder();
            CreateProducts();
            CreateProductPrices();
        }
        
        private void CreateProducts()
        {
            IList<Product> products = new List<Product>()
            {
                new Product()
                {
                    Version = "1.0",
                    ReleaseDate = DateTime.Now,
                    Name = "StorePro Standard",
                    Description = "Stand alone version for a single system",
                    FilePath = "http://storepro.nitware.com.ng/downloads/storepro_standard.exe",
                    ProductTypeId = 1,
                },
                new Product()
                {
                    Version = "1.0",
                    ReleaseDate = DateTime.Now,
                    Name = "StorePro Professional",
                    Description = "Network version for an intranet environment",
                    FilePath = "http://storepro.nitware.com.ng/downloads/storepro_professional.exe",
                    ProductTypeId = 2,
                },
                new Product()
                {
                    Version = "1.0",
                    ReleaseDate = DateTime.Now,
                    Name = "StorePro Enterprise",
                    Description = "Online version for shop in mulituple locations",
                    FilePath = "http://storepro.nitware.com.ng/downloads/storepro_enterprise.exe",
                    ProductTypeId = 3,
                },
            };
            
            _repository.AddRange<Product>(products);
            _repository.Save();
        }

        private void CreateProductPrices()
        {
            IList<ProductPrice> productPrices = new List<ProductPrice>()
            {
                new ProductPrice()
                {
                     ProductId = 1,
                     Price = 15000,
                     CreatedOn = DateTime.UtcNow,
                     CurrentProductPrice = new CurrentProductPrice()
                },
                new ProductPrice()
                {
                   ProductId = 2,
                   Price = 150000,
                   CreatedOn = DateTime.UtcNow,
                   CurrentProductPrice = new CurrentProductPrice()
                },
                new ProductPrice()
                {
                    ProductId = 3,
                    Price = 450000,
                    CreatedOn = DateTime.UtcNow,
                    CurrentProductPrice = new CurrentProductPrice()
                },
            };

            foreach (ProductPrice productPrice in productPrices)
            {
                _productPriceService.SetProductPrice(productPrice);
            }
        }

        private Cart CreateOrder(User customer, IList<ProductPrice> productPrices)
        {
            Cart cart = new Cart();
            cart.Customer = customer;
            cart.ProductPrices = productPrices;

            cart.Order = new Order();
            cart.Order.AmountPayable = 15500;
            cart.Order.PaymentChannelId = 1;
            cart.Order.OrderedById = cart.Customer.Id;
            cart.Order.OrderDate = DateTime.UtcNow;

            return cart;
        }

        [Fact]
        public void PlaceOrder_Should_ReturnPlaceOrderIfSuccessfull()
        {
            User customer = _repository.GetSingle<User>(1);
            IList<ProductPrice> productPrices = _repository.FindBy<ProductPrice>(x => x.Id <= 2).ToList();
            Cart cart = CreateOrder(customer, productPrices);
            

            OperationResult<Order> order = _orderService.PlaceOrder(cart);

            
            //Assert.NotNull(products);
            //Assert.NotNull(products[0].ProductType);
            //Assert.Equal(1, products.Count);
        }






    }
}
