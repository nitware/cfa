using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class DownloadMap : EntityTypeConfiguration<Download>
    {
        public DownloadMap()
        {
            ToTable("DOWNLOAD");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Download_Id");
            Property(x => x.ProductId).HasColumnName("Product_Id");
            Property(x => x.DownloadedFrom).HasColumnName("Downloaded_From").HasMaxLength(550);
            Property(x => x.DownloadDate).HasColumnName("Download_Date");

        }
    }



}
