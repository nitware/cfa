using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using CFA.Infrastructure.Extensions;

namespace CFA.Data.Core
{
    public class CFAContext : DbContext
    {
        public CFAContext() : base("CFA") { }
        public CFAContext(System.Data.Entity.Infrastructure.DbCompiledModel model) : base(model) { }
        public CFAContext(System.Data.Common.DbConnection connection, bool contextOwnsConnection) : base(connection, contextOwnsConnection)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CFAContext>());
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where t.Namespace.HasValue() &&
                                        t.BaseType != null &&
                                        t.BaseType.IsGenericType
                                  let genericType = t.BaseType.GetGenericTypeDefinition()
                                  where genericType == typeof(EntityTypeConfiguration<>) || genericType == typeof(ComplexTypeConfiguration<>)
                                  select t;

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            //or manually 
            //modelBuilder.Configurations.Add(new RoleMap());
            
            base.OnModelCreating(modelBuilder);
        }


        //public IDbSet<User> Users { get; set; }
        //public IDbSet<Role> Roles { get; set; }
        //public IDbSet<UserInRole> UserInRoles { get; set; }

    }
}
