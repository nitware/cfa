using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Threading;
using WebApiDoodle.Web.MessageHandlers;
using System.Security.Principal;
using CFA.API.Extensions;
using CFA.Service.Interfaces;
using CFA.Domain.Models;

namespace CFA.API.Handlers
{
    public class CFAAuthenticationHandler : BasicAuthenticationHandler
    {
        protected override Task<IPrincipal> AuthenticateUserAsync(HttpRequestMessage request, string username, string password, CancellationToken cancellationToken)
        {
            IMembershipService membershipService = request.GetMembershipService();
            UserContext userCtx = membershipService.ValidateUser(username, password);
            return Task.FromResult(userCtx.Principal);
        }





    }
}
