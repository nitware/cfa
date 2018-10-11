using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Effort;
using CFA.Data.Core;
using CFA.Data.Setup;
using System.Data.Entity;

namespace CFA.Test
{
    public class Db
    {
        public static CFAContext GetContext()
        {
            //EffortProviderConfiguration.RegisterProvider();

            var connection = DbConnectionFactory.CreateTransient();
            CFAContext context = new CFAContext(connection, true);
            Database.SetInitializer(new DropCreateDatabaseAlways<CFAContext>());
            DataSeeder.SeedData(context);

            return context;
        }




    }



}
