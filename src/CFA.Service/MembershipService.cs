using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Entities;
using CFA.Infrastructure.Extensions;
using CFA.Service.Interfaces;
using CFA.Service.Extensions;
using CFA.Domain.Models;
using System.Security.Principal;

namespace CFA.Service
{
    public class MembershipService : IMembershipService
    {
        private readonly IRepository _repository;
        private readonly ICryptoService _cryptoService;

        public MembershipService(IRepository repository, ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            _repository = repository;
        }

        public UserContext ValidateUser(string username, string password)
        {
            UserContext userCtx = null;
            var user = _repository.GetUserByUsername(username);
            if (user != null && IsUserValid(user, password))
            {
                userCtx = new UserContext();
                GenericIdentity identity = new GenericIdentity(user.Email);
                userCtx.Principal = new GenericPrincipal(identity, new string[] { user.Role.Name });
                userCtx.User = user;
            }

            return userCtx;
        }

        public OperationResult<User> CreateUser(string email, string password, string phone, string address, Role role = null)
        {
            //bool userExist = _repository.GetAll<User>().Any(x => x.Username == username);

            bool userExist = _repository.UserExist(email);
            if (userExist)
            {
                return new OperationResult<User>(false);
            }

            string passwordSalt = _cryptoService.GenerateSalt();
            string hashedPassword = _cryptoService.EncryptPassword(password, passwordSalt);
            role = role.IsNull() ? new Role() { Id = 2, Name = "Guest" } : role;

            var user = new User()
            {
                //Username = username,
                Password = hashedPassword,
                Salt = passwordSalt,
                Email = email,
                Phone = phone,
                Address = address,
                IsLocked = false,
                CreatedOn = DateTime.UtcNow,
                RoleId = role.Id

                //Role = role,
            };

            _repository.Add(user);
            _repository.Save();

            return new OperationResult<User>(true) { Entity = user };
        }

        public Role GetRoleBy(int id)
        {
            return _repository.GetSingle<Role>(id);
        }

        private bool IsUserValid(User user, string password)
        {
            if (IsPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }

        private bool IsPasswordValid(User user, string password)
        {
            return string.Equals(_cryptoService.EncryptPassword(password, user.Salt), user.Password);
        }







    }
}
