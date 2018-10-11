using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class ControllerMap : EntityTypeConfiguration<Controller>
    {
        public ControllerMap()
        {
            ToTable("CONTROLLER");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Controller_Id");
            Property(x => x.Name).HasColumnName("Controller_Name");
            Property(x => x.Description).HasColumnName("Controller_Description");
        }
    }


}
