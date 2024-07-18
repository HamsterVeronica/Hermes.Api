
using Hermes.Api.Domain.Model;
using System.Xml;

namespace Hermes.Api.Domain.Contracts.Repositories
{
    public interface IGuildMemberRepository
    {
        public void SaveGuildMembers(List<GuildMember> guildMembers);
        public List<GuildMember> LoadGuildMembers();
    }
}
