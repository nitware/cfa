using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CFA.Domain.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int PaymentChannelId { get; set; }
        public int OrderedById { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal AmountPayable { get; set; }
        public int SerialNo { get; set; }
        public string InvoiceNo { get; set; }

        public virtual IList<Esnecil> Esnecils { get; set; }
        public virtual PaymentChannel PaymentChannel { get; set; }
        public virtual User OrderedBy { get; set; }

    }



}
