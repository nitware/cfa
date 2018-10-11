using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class ActionMap : EntityTypeConfiguration<CFA.Domain.Entities.Action>
    {
        public ActionMap()
        {
            ToTable("ACTION");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Action_Id");
            Property(x => x.Name).HasColumnName("Action_Name");
            Property(x => x.Description).HasColumnName("Action_Description");
        }

    }
}
