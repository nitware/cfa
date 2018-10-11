using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Models;

namespace CFA.Service.Interfaces
{
    public interface IInvoiceManager
    {
        Invoice GetNextInvoiceNo();
    }
}
