using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.Model;
using Newtonsoft.Json;

namespace Hermes.Api.Infraestructure.Repositories
{
    public class GuildMemberRepository : IGuildMemberRepository
    {
        private const string FilePath = "../Guild Members/guildMembers.json";
        private const int MaxItems = 100;

        public void SaveGuildMembers(List<GuildMember> guildMembers)
        {
            var itemsToSave = guildMembers.Count > MaxItems ? guildMembers.GetRange(0, MaxItems) : guildMembers;
            var json = JsonConvert.SerializeObject(itemsToSave, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public List<GuildMember> LoadGuildMembers()
        {
            if (!File.Exists(FilePath))
                return new List<GuildMember>();

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<GuildMember>>(json);
        }
    }
}
