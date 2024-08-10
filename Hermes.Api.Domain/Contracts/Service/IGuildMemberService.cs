using Hermes.Api.Domain.Model;

namespace Hermes.Api.Domain.Contracts.Service
{
    public interface IGuildMemberService
    {
        public void SaveGuildMembers(List<GuildMember> guildMembers);
        public List<GuildMember> LoadGuildMembers();
        List<GuildMember> GenerateGuildMembers(int count);
        GuildMember GetGuildMemberById(int id);
        void CreateGuildMember(GuildMember member);
        void CreateGuildMembers(List<GuildMember> members);
        void UpdateGuildMember(GuildMember member);
        void DeleteGuildMember(int id);
    }
}
