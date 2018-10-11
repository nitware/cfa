using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Service.Interfaces;
using CFA.Domain.Models;

namespace CFA.Service
{
    public class NoDiscountCalculator : IDiscountCalculator
    {
        public decimal Compute()
        {
            return 0;
        }

        //public decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears)
        //{
        //    return 0;
        //}

    }


}
