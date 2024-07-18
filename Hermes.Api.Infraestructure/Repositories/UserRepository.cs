using Hermes.Api.Domain.Model;
using Newtonsoft.Json;
using System.Xml;

namespace Hermes.Api.Infraestructure.Repositories
{
    public class UserRepository
    {
        private const string FilePath = "users.json";
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
