using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CFA.Data.Mapping
{
    public class RightMap : EntityTypeConfiguration<Right>
    {
        public RightMap()
        {
            ToTable("RIGHT");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Right_Id");
            Property(x => x.Name).HasColumnName("Right_Name");
            Property(x => x.Description).HasColumnName("Right_Description");
            Property(x => x.ControllerActionId).HasColumnName("Controller_Action_Id");

           
        }


    }





}
