using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Domain.Models;

namespace CFA.Service.Interfaces
{
    public interface IOrderService
    {
        OperationResult<Order> PlaceOrder(Cart cart);

        //OperationResult<Order> PlaceOrder(Order order, IList<ProductPrice> productPrices, DiscountPolicy discountPolic);
    }



}
