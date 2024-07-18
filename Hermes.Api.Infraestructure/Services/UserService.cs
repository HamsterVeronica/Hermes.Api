using Hermes.Api.Domain.Model;
using Hermes.Api.Infraestructure.Repositories;

namespace Hermes.Api.Infraestructure.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void SaveUsers(List<User> users)
        {
            _userRepository.SaveUsers(users);
        }

        public List<User> LoadUsers()
        {
            return _userRepository.LoadUsers();
        }

        public List<User> GenerateUsers(int count)
        {
            var users = new List<User>();
            for (int i = 0; i < count; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = $"User{i}",
                    Password = $"Password{i}",
                    SecretWord = $"Secret{i}"
                });
            }
            return users;
        }
    }
}
