using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CFA.Domain.Entities
{
    public class Esnecil : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductPriceId { get; set; }
        public string EsnecilCode { get; set; }
        public string MachineKey { get; set; }
        public bool EnableTamperChecking { get; set; }
        public bool DetectDateRollback { get; set; }
        public string SerialCode { get; set; }
        public string RawUserData { get; set; }
        public int NoOfUsers { get; set; }
        public DateTime GeneratedOn { get; set; }
                
        public virtual ProductPrice ProductPrice { get; set; }
        public virtual Order Order { get; set; }
    }

   

}
