using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;

namespace CFA.Data.Setup
{
    public class Seed
    {
        public static IList<Controller> GetControllers()
        {
            IList<Controller> controllers = new List<Controller>()
            {
                new Controller() { Name = "Controller-1", Description = "Controller-1" },
                new Controller() { Name = "Controller-2", Description = "Controller-2" },
                new Controller() { Name = "Controller-3", Description = "Controller-3" },
                new Controller() { Name = "Controller-4", Description = "Controller-4" },
                new Controller() { Name = "Controller-5", Description = "Controller-5" },
            };

            return controllers;
        }

        public static IList<CFA.Domain.Entities.Action> GetActions()
        {
            IList<CFA.Domain.Entities.Action> actions = new List<CFA.Domain.Entities.Action>()
            {
                new CFA.Domain.Entities.Action() { Name = "Index", Description = "Index description" },
                new CFA.Domain.Entities.Action() { Name = "Action-1", Description = "Action-1 description" },
                new CFA.Domain.Entities.Action() { Name = "Action-2", Description = "Action-2 description" },
                new CFA.Domain.Entities.Action() { Name = "Action-3", Description = "Action-3 description" },
                new CFA.Domain.Entities.Action() { Name = "Action-4", Description = "Action-4 description" },
                new CFA.Domain.Entities.Action() { Name = "Action-5", Description = "Action-5 description" },
            };

            return actions;
        }
       
        public static IList<Role> GetRoles(IQueryable<Right> rights)
        {
            IList<Role> roles = new List<Role>()
            {
                new Role() { Name = "Affiliate", Rights = rights.Where(x => x.Id == 2).ToList() },
                new Role() { Name = "Guest", Rights = rights.Where(x => x.Id == 3).ToList() },
                new Role() { Name = "Admin", Rights = rights.ToList() },
            };

            return roles;
        }

        public static IList<ControllerAction> GetControllerActions(IQueryable<Controller> controllers, IQueryable<CFA.Domain.Entities.Action> actions)
        {
            IList<ControllerAction> controllerActions = new List<ControllerAction>()
            {
                new ControllerAction() { Action = actions.SingleOrDefault(x => x.Name == "Index"), Controller = controllers.SingleOrDefault(x => x.Name == "Controller-1") },
                new ControllerAction() { Action = actions.SingleOrDefault(x => x.Name == "Action-1"), Controller = controllers.SingleOrDefault(x => x.Name == "Controller-1") },
                new ControllerAction() { Action = actions.SingleOrDefault(x => x.Name == "Action-2"), Controller = controllers.SingleOrDefault(x => x.Name == "Controller-1") },
                new ControllerAction() { Action = actions.SingleOrDefault(x => x.Name == "Action-3"), Controller = controllers.SingleOrDefault(x => x.Name == "Controller-1") },
            };

            return controllerActions;
        }
        
        public static IList<Right> GetRights(IQueryable<ControllerAction> controllerActions)
        {
            IList<Right> rights = new List<Right>()
            {
                new Right() { Name = "Can add user", ControllerAction  = controllerActions.SingleOrDefault(x => x.Id == 1) },
                new Right() { Name = "Can view user", ControllerAction = controllerActions.SingleOrDefault(x => x.Id == 2) },
                new Right() { Name = "Can place order", ControllerAction = controllerActions.SingleOrDefault(x => x.Id == 3) },
                new Right() { Name = "Can delete order", ControllerAction = controllerActions.SingleOrDefault(x => x.Id == 4) },
            };

            return rights;
        }

        public static IList<User> GetUsers(IList<Role> roles)
        {
            IList<User> users = new List<User>()
            {
                new User()
                {
                    Phone = "09087765432",
                    Address = "2 Olopa road, Ikeja Lagos",
                    Email  = "admin@app.com",
                    Password = "xxx",
                    CreatedOn = DateTime.UtcNow,
                    IsLocked = false,
                    Role = roles[0],
                    Salt = "xxx",
                    LastUpdatedOn = DateTime.UtcNow
                },

                new User()
                {
                    Phone = "08070001234",
                    Address = "22 Ife Plaza, Lekki Phase 1, Lagos",
                    Email  = "guest@app.com",
                    Password = "xxx",
                    CreatedOn = DateTime.UtcNow,
                    IsLocked = false,
                    Role = roles[1],
                    Salt = "xxx",
                    LastUpdatedOn = DateTime.UtcNow
                },
            };

            return users;
        }

        public static IList<ProductType> GetProductTypes()
        {
            IList<ProductType> productTypes = new List<ProductType>()
            {
                new ProductType() { Name = "StorePro Standard", Description = "Standalone version for a single system" },
                new ProductType() { Name = "StorePro Professional", Description = "Network version that can be installed just on an intranet" },
                new ProductType() { Name = "StorePro Enterprise", Description = "Network version that runs on the internet for stores located in diffrent locations" },
                new ProductType() { Name = "StorePro Mobile", Description = "Mobile App version for mobile app users" },
              
            };

            return productTypes;
        }

        public static IList<PaymentChannel> GetPaymentChannels()
        {
            IList<PaymentChannel> paymentChannels = new List<PaymentChannel>()
            {
                new PaymentChannel() { Name = "Paystack" },
                new PaymentChannel() { Name = "Interswitch" },

            };

            return paymentChannels;
        }

        //public static IList<ProductPrice> GetProductPrices(IQueryable<ProductPrice> controllerActions)
        //{
        //    IList<ProductType> rights = new List<ProductType>()
        //    {
        //        new Right() { Name = "Can add user", ControllerAction  = controllerActions.SingleOrDefault(x => x.Id == 1) },
        //        new Right() { Name = "Can view user", ControllerAction = controllerActions.SingleOrDefault(x => x.Id == 2) },
        //        new Right() { Name = "Can place order", ControllerAction = controllerActions.SingleOrDefault(x => x.Id == 3) },
        //        new Right() { Name = "Can delete order", ControllerAction = controllerActions.SingleOrDefault(x => x.Id == 4) },
        //    };

        //    return rights;
        //}






    }


}
