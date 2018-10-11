using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("ROLE");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Role_Id");
            Property(x => x.Name).HasColumnName("Role_Name");
            Property(x => x.Description).HasColumnName("Role_Description");

            HasMany(t => t.Rights)
                .WithMany(a => a.Roles)
                .Map(c => c.ToTable("ROLE_RIGHT"));
            
              
        }


    }



}
