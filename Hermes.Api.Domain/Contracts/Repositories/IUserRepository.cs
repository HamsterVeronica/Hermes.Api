using Hermes.Api.Domain.Model;

namespace Hermes.Api.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        public void SaveUsers(List<User> users);
        public List<User> LoadUsers();
    }
}
