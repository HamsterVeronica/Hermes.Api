using Hermes.Api.Domain.Model;

namespace Hermes.Api.Domain.Contracts.Service
{
    public interface IUserService
    {
        public void SaveUsers(List<User> users);
        public List<User> LoadUsers();
        public List<User> GenerateUsers(int count);
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
