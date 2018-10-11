using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using CFA.Domain.Entities;
using CFA.Service.Interfaces;
using CFA.Service.Extensions;
using CFA.Data;
using CFA.Test;
using CFA.Domain.Models;
using Moq;

namespace CFA.Service.Test
{
    public class MembershipServiceTest
    {
        private IRepository _repository;
        private ICryptoService _cryptoService;
        private IMembershipService _membershipService;

        //private Mock<IRepository> _repository;
        //private Mock<ICryptoService> _cryptoService;
        //private IMembershipService _membershipService;

        public MembershipServiceTest()
        {
            var dbContext = Db.GetContext();
            _cryptoService = new CryptoService();
            _repository = new Repository(dbContext);
            _membershipService = new MembershipService(_repository, _cryptoService);

            ////_repository = new Mock<IRepository>();
            //_cryptoService = new Mock<ICryptoService>();
            //_membershipService = new MembershipService(_repository, _cryptoService.Object);
        }

        [Fact]
        public void Should_CreateUser_WhenNewUserIsSet()
        {
            //string username = "abc";
            string email = "abc@mail.com";
            string password = "09081112345";
            string phone = "abc@mail.com";
            string address = "1, Egenti Street, Lekki Phase 1, Lagos";

            CreateUser(email, password, phone, address);
        }

        [Theory]
        [InlineData("abc@mail.com", "123", "09081112345", "23, Egenti Street, Lekki Phase 1, Lagos")]
        [InlineData("xyz@mail.com", "456", "07031392115", "1, Egenti Street, Lekki Phase 1, Lagos")]
        public void CanLoginAsExistingUser(string email, string password, string phone, string address)
        {
            CreateUser(email, password, phone, address);
            
            User user = _repository.GetUserByUsername(email);
            UserContext userContext = _membershipService.ValidateUser(email, password);

            Assert.NotNull(userContext.User);
            //Assert.Equal(username, userContext.User.Username);
            Assert.Equal(user.Password, userContext.User.Password);
            Assert.Equal(user.Salt, userContext.User.Salt);
            Assert.Equal(email, userContext.User.Email);
        }

        private void CreateUser(string email, string password, string phone, string address)
        {
            OperationResult<User> result = _membershipService.CreateUser(email, password, phone, address);
            int roleCount = _repository.GetAll<Role>().Count();
            int userCount = _repository.GetAll<User>().Count();

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Entity);
            Assert.Equal(email, result.Entity.Email);
            Assert.Equal(3, roleCount);
            Assert.Equal(3, userCount);
        }




    }
}
