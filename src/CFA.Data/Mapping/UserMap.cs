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
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("USER");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("User_Id");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.Salt).HasColumnName("Salt").HasMaxLength(2000);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Email") { IsUnique = true })); ;
            Property(x => x.Phone).HasColumnName("Phone");
            Property(x => x.Address).HasColumnName("Address");
            Property(x => x.IsLocked).HasColumnName("Is_Locked");
            Property(x => x.CreatedOn).HasColumnName("Created_On");
            Property(x => x.LastUpdatedOn).HasColumnName("Last_Updated_On");

            //Property(x => x.RoleId).HasColumnName("Role_Id");
            //Property(x => x.Username).HasColumnName("Username");

            HasRequired(x => x.Role).WithMany(x => x.Users);
        }


    }



}
