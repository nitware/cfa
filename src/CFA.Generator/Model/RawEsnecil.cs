using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Generator.Model
{
    public class RawEsnecil
    {
        public string EsnecilCode { get; set; }
        public string MachineKey { get; set; }
        public bool EnableTamperChecking { get; set; }
        public bool DetectDateRollback { get; set; }
        public string SerialCode { get; set; }
        public string RawUserData { get; set; }
        public int NoOfUsers { get; set; }
        public DateTime GeneratedOn { get; set; }
    }



}
