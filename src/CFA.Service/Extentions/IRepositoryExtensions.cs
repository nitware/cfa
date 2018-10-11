using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Service.Interfaces;

namespace CFA.Service.Extensions
{
    public static class IRepositoryExtensions
    {
        public static Role GetRoleByName(this IRepository repository, string roleName)
        {
            return repository.FindBy<Role>(x => x.Name == roleName).SingleOrDefault();
        }

        public static User GetUserByUsername(this IRepository repository, string username)
        {
            //return repository.FindBy<User>(x => x.Username == username).SingleOrDefault();
            return repository.FindBy<User>(x => x.Email == username).SingleOrDefault();
        }

        public static bool UserExist(this IRepository repository, string username)
        {
            //IQueryable<User> users = repository.GetAll<User>();

            bool found = false;
            User user = repository.GetSingle<User>(x => x.Email == username);
            if (user != null)
            {
                found = true;
            }
                       
            return found;
        }


    }
}
