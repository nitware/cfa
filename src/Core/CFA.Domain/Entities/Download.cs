using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Interfaces;

namespace CFA.Domain.Entities
{
    public class Download : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string DownloadedFrom { get; set; }
        public DateTime DownloadDate { get; set; }

        public Product Product { get; set; }




    }

}
