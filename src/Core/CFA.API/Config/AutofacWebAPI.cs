using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Data.Entity;
using CFA.Data.Core;
using CFA.Service.Interfaces;
using CFA.Service;
using CFA.Data;

namespace CFA.API.Config
{
    public class AutofacWebAPI
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //EF DbContext
            builder.RegisterType<CFAContext>().As<DbContext>().InstancePerApiRequest();

            //Repositories
            builder.RegisterType<Repository>().As<IRepository>().InstancePerApiRequest();

            //Services
            builder.RegisterType<CryptoService>().As<ICryptoService>().InstancePerApiRequest();
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerApiRequest();
            
            return builder.Build();
        }



    }
}
