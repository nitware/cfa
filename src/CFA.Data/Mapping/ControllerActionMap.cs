using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class ControllerActionMap : EntityTypeConfiguration<ControllerAction>
    {
        public ControllerActionMap()
        {
            ToTable("CONTROLLER_ACTION");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Controller_Action_Id");
            Property(x => x.ControllerId).HasColumnName("Controller_Id");
            Property(x => x.ActionId).HasColumnName("Action_Id");

        }



    }
}
