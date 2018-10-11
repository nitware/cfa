using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Domain.Models;
using CFA.Service.Interfaces;
using CFA.Generator.Model;
using CFA.Generator;
using CFA.Service.Extentions;

//using CFA.Service.Extensions;

namespace CFA.Service
{
    public class OrderService : IOrderService
    {
        private IRepository _repository;
        private IInvoiceManager _invoiceManager;
        private EsnecilGeneratorBase _esnecilGenerator;

        public OrderService(IRepository repository, IInvoiceManager invoiceManager, EsnecilGeneratorBase esnecilGenerator)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            if (esnecilGenerator == null)
            {
                throw new ArgumentNullException("esnecilGenerator");
            }
            if (invoiceManager == null)
            {
                throw new ArgumentNullException("invoiceManager");
            }

            _repository = repository;
            _esnecilGenerator = esnecilGenerator;
            _invoiceManager = invoiceManager;
        }
        
        public OperationResult<Order> PlaceOrder(Cart cart)
        {
            const int MAX_RETRY = 10;

            if (cart == null)
            {
                throw new ArgumentNullException("cart");
            }

            Dictionary<string, string> customerInfo = new Dictionary<string, string>();
            customerInfo.Add("Email", cart.Customer.Email);
            customerInfo.Add("Phone", cart.Customer.Phone);
            customerInfo.Add("Address", cart.Customer.Address);
            customerInfo.Add("CodeID", cart.Customer.Id.ToString());
            //customerInfo.Add("Name", cart.Customer.Email);

            cart.Order.Esnecils = new List<Esnecil>();
            foreach (ProductPrice productPrice in cart.ProductPrices)
            {
                RawEsnecil rawEsnecil = _esnecilGenerator.GenerateLicense(customerInfo);
                Esnecil esnecil = rawEsnecil.ToEsnecil();
                esnecil.ProductPriceId = productPrice.Id;
                cart.Order.Esnecils.Add(esnecil);
            }
            
            for (int i = 1; i <= MAX_RETRY; i++)
            {
                try
                {
                    Invoice invoice = _invoiceManager.GetNextInvoiceNo();
                    cart.Order.InvoiceNo = invoice.InvoiceNo;
                    cart.Order.SerialNo = invoice.SerialNo;

                    _repository.Add(cart.Order);
                    _repository.Save();

                    break;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                    {
                        if (i == MAX_RETRY)
                        {
                            throw new Exception("Violation of UNIQUE KEY constraint. Cannot insert duplicate key in object. The statement has been terminated. Please try again.");
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            
            return new OperationResult<Order>(true) { Entity = cart.Order };
        }


        

        




    }


}
