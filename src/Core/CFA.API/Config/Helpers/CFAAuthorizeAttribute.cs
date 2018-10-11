using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using CFA.Service.Interfaces;
using CFA.API.Extensions;
using CFA.Infrastructure.Extensions;
using CFA.Domain.Entities;
using System.Net;

namespace CFA.API.Config.Helpers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CFAAuthorizeAttribute : AuthorizeAttribute
    {
        public CFAAuthorizeAttribute(int roleId)
        {
            RoleId = roleId;
        }

        public int RoleId { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            bool hasRight = false;
            HttpRequestMessage request = actionContext.Request;
            IMembershipService membershipService = request.GetMembershipService();
            Role role = membershipService.GetRoleBy(RoleId);

            if (role.HasValue())
            {
                IList<Right> rights = role.Rights;
                if (rights.HasItem())
                {
                    string actionName = actionContext.ActionDescriptor.ActionName;
                    string controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

                    Right right = rights.SingleOrDefault(x => string.Equals(controllerName, x.ControllerAction.Controller.Name) && string.Equals(actionName, x.ControllerAction.Action.Name));
                    hasRight = right.HasValue() ? true : false;


                    //string[] rt = rights.Select(x => x.Name).ToArray();
                    //foreach (Right right in rights)
                    //{
                    //    if (string.Equals(controllerName, right.ControllerAction.Controller.Name) && string.Equals(actionName, right.ControllerAction.Action.Name))
                    //    {
                    //        hasRight = true;
                    //        break;
                    //    }
                    //}
                }
            }

            if (hasRight)
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

















        //public CFAAuthorizeAttribute()
        //{
        //    base.Roles = "Affiliate";
        //}

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    base.OnAuthorization(actionContext);

        //    // If not authorized at all, don't bother
        //    // checking for the user - affiliate relation
        //    if (actionContext.Response == null)
        //    {
        //        // We are here sure that the request
        //        // has been authorized and the user is
        //        // in the Affiliate role. We also don't need
        //        // to check the existence of the affiliate
        //        // as it has been also already done
        //        // by AffiliateShipmentsDispatcher.
        //        HttpRequestMessage request = actionContext.Request;
        //        Guid affiliateKey = GetAffiliateKey(request.GetRouteData());

        //        IPrincipal principal = Thread.CurrentPrincipal;
        //        IShipmentService shipmentService = request.GetShipmentService();
        //        bool isAffiliateRelatedToUser = shipmentService.IsAffiliateRelatedToUser(affiliateKey, principal.Identity.Name);

        //        if (!isAffiliateRelatedToUser)
        //        {
        //            // Set Unauthorized response
        //            // as the user and affiliate isn't
        //            // related to each other. You might want to
        //            // return "404 NotFound" response here
        //            // if you don't want to expose the existence of the affiliate.
        //            actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized);
        //        }

        //    }
        //}





    }
}
