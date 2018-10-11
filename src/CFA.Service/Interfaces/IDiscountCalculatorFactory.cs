using CFA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Service.Interfaces
{
    public interface IDiscountCalculatorFactory
    {
        IDiscountCalculator Get(DiscountPolicy type);

    }
}
