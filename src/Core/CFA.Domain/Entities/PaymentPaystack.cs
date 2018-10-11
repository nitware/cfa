using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Domain.Entities
{
    public class PaymentPaystack
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string Reference { get; set; }
        public string Domain { get; set; }
        public string GatewayResponse { get; set; }
        public string Message { get; set; }
        public string Channel { get; set; }
        public string IPAddress { get; set; }
        public string Fees { get; set; }
        public string Last4 { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string CardType { get; set; }
        public string Bank { get; set; }
        public string CurrencyCode { get; set; }
        public string Brand { get; set; }
        public bool ReUsable { get; set; }
        public string Signature { get; set; }
        public string AuthorizationUrl { get; set; }
        public string AccessCode { get; set; }

        public Order Order { get; set; }

    }


}
