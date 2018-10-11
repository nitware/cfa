using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Service.Interfaces;
using CFA.Domain.Models;
using CFA.Domain.Entities;

namespace CFA.Service
{
    public class InvoiceManager : IInvoiceManager
    {
        private IRepository _repository;

        public InvoiceManager(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public Invoice GetNextInvoiceNo()
        {
            Invoice invoice = new Invoice();
            int maximumSerialNo = _repository.GetMaxValueBy<Order>(o => o.SerialNo);
            if (maximumSerialNo > 0)
            {
                //maximumSerialNo = ++maximumSerialNo;
                invoice.SerialNo = ++maximumSerialNo;
                invoice.InvoiceNo = "NTK" + DateTime.UtcNow.ToString("yy") + PaddNumber(maximumSerialNo, 10);
            }

            return invoice;
        }

        private string PaddNumber(int id, int maxCount)
        {
            string paddNumbers = "";
            string idInString = id.ToString();

            if (idInString.Count() < maxCount)
            {
                int zeroCount = maxCount - id.ToString().Count();
                StringBuilder builder = new StringBuilder();
                for (int counter = 0; counter < zeroCount; counter++)
                {
                    builder.Append("0");
                }

                builder.Append(id);
                paddNumbers = builder.ToString();

                return paddNumbers;
            }

            return paddNumbers;
        }

        //private bool SetInvoiceNo(Payment payment)
        //{
        //    try
        //    {
        //        PAYMENT entity = _da.GetSingleBy<PAYMENT>(p => p.Payment_Id == payment.Id);
        //        if (entity == null)
        //        {
        //            throw new Exception("NoItemFound");
        //        }

        //        entity.Serial_Number = payment.SerialNumber;
        //        entity.Invoice_Number = payment.InvoiceNumber;

        //        return _da.Update(entity);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



    }
}
