using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.Contracts.Service;
using Hermes.Api.Domain.Model;

namespace Hermes.Api.Infraestructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;

        public UserService(IUserRepository userRepository, IPasswordHashService passwordHashService)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
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
                    Password = _passwordHashService.HashPassword($"Password{i}"),
                    SecretWord = $"Secret{i}"
                });
            }
            return users;
        }

        public User GetUserById(int id)
        {
            return _userRepository.LoadUsers().FirstOrDefault(u => u.Id == id);
        }

        public void CreateUser(User user)
        {
            var users = _userRepository.LoadUsers();
            if (users.Count >= 100)
            {
                throw new Exception("User limit reached");
            }

            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;

            user.Password = _passwordHashService.HashPassword(user.Password);
            users.Add(user);
            SaveUsers(users);
        }

        public void CreateUsers(List<User> newUsers)
        {
            var users = _userRepository.LoadUsers();
            if (users.Count + newUsers.Count > 100)
            {
                throw new Exception("Member limit reached");
            }

            int nextId = users.Any() ? users.Max(m => m.Id) + 1 : 1;
            foreach (var member in newUsers)
            {
                member.Id = nextId++;
                users.Add(member);
            }
            SaveUsers(users);
        }

        public void UpdateUser(User user)
        {
            var users = _userRepository.LoadUsers();
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Password = _passwordHashService.HashPassword(user.Password);
                existingUser.SecretWord = user.SecretWord;
                SaveUsers(users);
            }
        }

        public void DeleteUser(int id)
        {
            var users = _userRepository.LoadUsers();
            var userToDelete = users.FirstOrDefault(u => u.Id == id);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                SaveUsers(users);
            }
        }
    }
}
