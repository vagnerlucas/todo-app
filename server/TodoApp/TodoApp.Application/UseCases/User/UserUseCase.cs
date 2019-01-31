using System;
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
        public Task<Guid> CreateUser(UserInput user)
        {
            var userDomain = GenerateDomainUser(user);
            return _userWriteOnlyRepository.CreateUser(userDomain);
        }

        public async Task<UserOutput> GetUser(string name)
        {
            var data = await _userReadOnlyRepository.GetUser(name);
            return new UserOutput(data);
        }

        internal static Domain.User.User GenerateDomainUser(UserInput user)
        {
            return new Domain.User.User
            {
                Name = user.Name
            };
        }

    }
}