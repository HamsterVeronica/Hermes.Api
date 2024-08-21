using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.Model;
using Newtonsoft.Json;

namespace Hermes.Api.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string FilePath = "../database/users/users.json";
        private const int MaxItems = 100;

        public void SaveUsers(List<User> users)
        {
            var itemsToSave = users.Count > MaxItems ? users.GetRange(0, MaxItems) : users;
            var json = JsonConvert.SerializeObject(itemsToSave, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public List<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new List<User>();

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
    }
}
