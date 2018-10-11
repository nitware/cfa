using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity.Migrations;

namespace CFA.API.WebHost
{
    public class EFConfig
    {
        public static void Initialize()
        {
            RunMigrations();
        }

        private static void RunMigrations()
        {
            //var efMigrationSettings = new Configuration();
            //var efMigrator = new DbMigrator(efMigrationSettings);

            //efMigrator.Update();
        }




    }
}