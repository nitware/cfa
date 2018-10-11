using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class PaymentPaystackMap : EntityTypeConfiguration<PaymentPaystack>
    {
        public PaymentPaystackMap()
        {
            ToTable("PAYMENT_PAYSTACK");
            HasKey(x => x.OrderId);
            Property(x => x.OrderId).HasColumnName("Order_Id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Amount).HasColumnName("Amount");
            Property(x => x.Currency).HasColumnName("Currency").HasMaxLength(50);
            Property(x => x.TransactionDate).HasColumnName("Transaction_Date");
            Property(x => x.Status).HasMaxLength(50);
            Property(x => x.Reference).HasMaxLength(50);
            Property(x => x.Domain).HasMaxLength(50);
            Property(x => x.GatewayResponse).HasColumnName("Gateway_Response").HasMaxLength(50);
            Property(x => x.Message).HasMaxLength(50);
            Property(x => x.Channel).HasMaxLength(50);
            Property(x => x.IPAddress).HasColumnName("IP_Address").HasMaxLength(50);
            Property(x => x.Fees).HasMaxLength(50);
            Property(x => x.Last4).HasMaxLength(50);
            Property(x => x.ExpiryMonth).HasColumnName("Expiry_Month").HasMaxLength(50);
            Property(x => x.ExpiryYear).HasColumnName("Expiry_Year").HasMaxLength(50);
            Property(x => x.CardType).HasColumnName("Card_Type").HasMaxLength(50);
            Property(x => x.Bank).HasMaxLength(50);
            Property(x => x.CurrencyCode).HasColumnName("Currency_Code").HasMaxLength(50);
            Property(x => x.Brand).HasMaxLength(50);
            Property(x => x.Signature).HasMaxLength(50);
            Property(x => x.AuthorizationUrl).HasColumnName("Authorization_Url");
            Property(x => x.AccessCode).HasColumnName("Access_Code").HasMaxLength(50);

            HasRequired(x => x.Order).WithRequiredDependent();

        }
    }



}
