using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Application.Repositories.UserRepository;

namespace TodoApp.Application.UseCases.User
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

        public UserUseCase(IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
        }
        public async Task<UserOutput?> CreateUser(UserInput user)
        {
            var userDomain = GenerateDomainUser(user);
            var id = await _userWriteOnlyRepository.CreateUser(userDomain);
            userDomain.Id = id;
            return new UserOutput(userDomain);
        }

        public async Task<UserOutput?> GetUser(string name)
        {
            var data = await _userReadOnlyRepository.GetUser(name);
            if (data == null)
                throw new UserNotFoundException("Impossible to find user");
            return new UserOutput(data);
        }

        private static Domain.User.User GenerateDomainUser(UserInput user)
        {
            return new Domain.User.User
            {
                Name = user.Name,
                Tasks = new List<Domain.Task.Task>()
            };
        }

    }
}