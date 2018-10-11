using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class PaymentChannelMap : EntityTypeConfiguration<PaymentChannel>
    {
        public PaymentChannelMap()
        {
            ToTable("PAYMENT_CHANNEL");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Payment_Channel_Id");
            Property(x => x.Name).HasColumnName("Payment_Channel_Name").HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasColumnName("Payment_Channel_Description").HasMaxLength(350);
           
            
        }
    }



}
