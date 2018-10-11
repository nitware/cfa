using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFA.Data.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("ORDER");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Order_Id");
            Property(x => x.OrderedById).HasColumnName("Ordered_By");
            Property(x => x.PaymentChannelId).HasColumnName("Payment_Channel_Id");
            Property(x => x.AmountPayable).HasColumnName("Amount_Payable").HasColumnType("money");
            Property(x => x.InvoiceNo).HasColumnName("Invoice_No").IsOptional().HasMaxLength(30).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Invoice_No") { IsUnique = true }));
            Property(x => x.SerialNo).HasColumnName("Serial_No").IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Serial_No") { IsUnique = true }));
            Property(x => x.OrderDate).HasColumnName("Order_Date");
            
            HasMany(o => o.Esnecils)
               .WithRequired(o => o.Order)
               .WillCascadeOnDelete(false);

            

        }
    }



}
