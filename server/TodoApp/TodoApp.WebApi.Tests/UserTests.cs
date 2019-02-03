using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Application.Repositories.UserRepository;
using TodoApp.Application.UseCases.User;
using TodoApp.Domain;
using TodoApp.Domain.User;
using Xunit;
using Assert = Xunit.Assert;

namespace TodoApp.WebApi.Tests
{
    [TestClass]
    public class UserTests
    {
        #region Data Mocking

        public static IEnumerable<object[]> GetEmptyUser()
        {
            yield return new object[]
            {
                new UserInput()
            };
        }

        public UserInput GetNewUser(string name)
        {
            return new UserInput
            {
                Name = name
            };
        }

        #endregion


        [Theory, MemberData(nameof(GetEmptyUser))]
        public async Task New_User_Should_Have_Name(UserInput user)
        {
            var mockUserWriteOnlyRepository = new Mock<IUserWriteOnlyRepository>();
            var sut = new UserUseCase(null, mockUserWriteOnlyRepository.Object);

            await Assert.ThrowsAsync<InvalidValueException>(() => sut.CreateUser(user));
        }

        [Theory]
        [InlineData("New User 1")]
        [InlineData("New User 2")]
        public async Task Should_Create_User(string name)
        {
            var mockUserWriteOnlyRepository = new Mock<IUserWriteOnlyRepository>();

            mockUserWriteOnlyRepository.Setup(repo => repo.CreateUser(It.IsAny<User>()))
                                       .ReturnsAsync(Guid.NewGuid());

            var sut = new UserUseCase(null, mockUserWriteOnlyRepository.Object);

            var user = GetNewUser(name);

            var newUser = await sut.CreateUser(user);

            Assert.True(newUser != null);
        }
    }
}
