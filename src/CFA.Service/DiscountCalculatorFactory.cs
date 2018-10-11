using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Service.Interfaces;
using CFA.Domain.Models;

namespace CFA.Service
{
    public class DiscountCalculatorFactory : IDiscountCalculatorFactory
    {
        public IDiscountCalculator Get(DiscountPolicy type)
        {
            IDiscountCalculator discountCalculator;

            switch (type)
            {
                case DiscountPolicy.None:
                    {
                        discountCalculator = new NoDiscountCalculator();
                        break;
                    }
                //case DiscountType.Percent:
                //    {

                //        break;
                //    }
                //case DiscountType.FixedRate:
                //    {

                //        break;
                //    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            return discountCalculator;
        }






    }
}
