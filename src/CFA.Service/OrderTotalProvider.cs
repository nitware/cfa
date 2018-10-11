using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Service.Interfaces;
using CFA.Infrastructure.Extensions;
using CFA.Domain.Entities;
using CFA.Domain.Models;

namespace CFA.Service
{
    public class OrderTotalProvider : IOrderTotalProvider
    {
        private IDiscountCalculatorFactory _discountCalculatorFactory;

        public OrderTotalProvider(IDiscountCalculatorFactory discountCalculatorFactory)
        {
            if (discountCalculatorFactory == null)
            {
                throw new ArgumentNullException("discountCalculatorFactory");
            }

            _discountCalculatorFactory = discountCalculatorFactory;
        }

        public decimal GetTotalPrice(IList<ProductPrice> productPrices, DiscountPolicy discountPolicy)
        {
            if(productPrices.IsEmpty())
            {
                throw new ArgumentNullException("productPrices");
            }

            IDiscountCalculator discountCalculator = _discountCalculatorFactory.Get(discountPolicy);
            decimal totalPrice = productPrices.Sum(x => x.Price);
            decimal discount = discountCalculator.Compute();

            return totalPrice - discount;
        }

        


    }



}
