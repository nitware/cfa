using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Data.Core;
using CFA.Service.Interfaces;
using CFA.Domain.Entities;
using System.Data.Entity;
using CFA.Infrastructure.Extensions;

namespace CFA.Data.Setup
{
    public class DataSeeder
    {
        public static void SeedData(CFAContext _dbContext)
        {
            // add Action, Controller
            IRepository repository = new Repository(_dbContext);
            IQueryable<CFA.Domain.Entities.Action> existingActions = repository.GetAll<CFA.Domain.Entities.Action>();
            if (existingActions.IsEmpty())
            {
                IList<CFA.Domain.Entities.Action> actions = Seed.GetActions();
                repository.AddRange(actions);
                repository.Save();
            }

            IQueryable<Controller> existingControllers = repository.GetAll<Controller>();
            if (existingControllers.IsEmpty())
            {
                IList<Controller> controllers = Seed.GetControllers();
                repository.AddRange(controllers);
                repository.Save();
            }

            // add ControllerAction
            IQueryable<ControllerAction> existingControllerActions = repository.GetAll<ControllerAction>();
            if (existingControllerActions.IsEmpty())
            {
                IQueryable<Controller> addedControllers = repository.GetAll<Controller>();
                IQueryable<CFA.Domain.Entities.Action> addedActions = repository.GetAll<CFA.Domain.Entities.Action>();
                IList<ControllerAction> controllerActions = Seed.GetControllerActions(addedControllers, addedActions);
                repository.AddRange(controllerActions);
                repository.Save();
            }

            IQueryable<Right> existingRights = repository.GetAll<Right>();
            if (existingRights.IsEmpty())
            {
                IQueryable<ControllerAction> cas = repository.GetAll<ControllerAction>();
                IList<Right> rights = Seed.GetRights(cas);
                repository.AddRange(rights);
                repository.Save();
            }

            IQueryable<Role> existingRoles = repository.GetAll<Role>();
            if (existingRoles.IsEmpty())
            {
                IQueryable<Right> addedRights = repository.GetAll<Right>();
                IList<Role> roles = Seed.GetRoles(addedRights);
                repository.AddRange(roles);
                repository.Save();
            }

            IQueryable<User> existingUsers = repository.GetAll<User>();
            if (existingUsers.IsEmpty())
            {
                IList<Role> addedRoles = repository.GetAll<Role>().ToList();
                IList<User> users = Seed.GetUsers(addedRoles);
                repository.AddRange(users);
                repository.Save();
            }

            IQueryable<PaymentChannel> existingPaymentChannels = repository.GetAll<PaymentChannel>();
            if (existingPaymentChannels.IsEmpty())
            {
                IList<PaymentChannel> paymentChannels = Seed.GetPaymentChannels();
                repository.AddRange(paymentChannels);
                repository.Save();
            }

            IQueryable<ProductType> existingProductTypes = repository.GetAll<ProductType>();
            if (existingProductTypes.IsEmpty())
            {
                IList<ProductType> productTypes = Seed.GetProductTypes();
                repository.AddRange(productTypes);
                repository.Save();
            }



        }
    }





}
