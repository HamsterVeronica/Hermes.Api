using Hermes.Api.Domain.Model;

namespace Hermes.Api.Domain.Contracts.Service
{
    public interface IGuildMemberService
    {
        public void SaveGuildMembers(List<GuildMember> guildMembers);
        public List<GuildMember> LoadGuildMembers();
        public List<GuildMember> GenerateGuildMembers(int count);

    }
}
