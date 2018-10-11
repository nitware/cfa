using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Web.Http.Dependencies;
using CFA.Service.Interfaces;

namespace CFA.API.Extensions
{
    internal static class HttpRequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        //internal static IShipmentService GetShipmentService(this HttpRequestMessage request)
        //{
        //    return request.GetService<IShipmentService>();
        //}

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }




    }
}
