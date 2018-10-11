using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Domain.Models;
using CFA.Infrastructure;

namespace CFA.Service.Interfaces
{
    public interface IMembershipService
    {
        UserContext ValidateUser(string username, string password);
        OperationResult<User> CreateUser(string email, string password, string phone, string address, Role role = null);
        Role GetRoleBy(int id);



        //UserWithRoles UpdateUser(User user, string username, string email);
        //bool ChangePassword(string username, string oldPassword, string newPassword);
        //bool AddToRole(Guid userKey, string role);
        //bool AddToRole(string username, string role);
        //bool RemoveFromRole(string username, string role);
        //IEnumerable<Role> GetRoles();
        //Role GetRole(Guid key);
        //Role GetRole(string name);
        //PaginatedList<UserWithRoles> GetUsers(int pageIndex, int pageSize);
        //UserWithRoles GetUser(Guid key);
        //UserWithRoles GetUser(string name);

    }




}
