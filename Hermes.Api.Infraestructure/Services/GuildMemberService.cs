using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.Model;

namespace Hermes.Api.Infraestructure.Services
{
    public class GuildMemberService
    {
        private readonly IGuildMemberRepository _guildMemberRepository;

        public GuildMemberService(IGuildMemberRepository guildMemberRepository)
        {
            _guildMemberRepository = guildMemberRepository;
        }

        public void SaveGuildMembers(List<GuildMember> guildMembers)
        {
            _guildMemberRepository.SaveGuildMembers(guildMembers);
        }

        public List<GuildMember> LoadGuildMembers()
        {
            return _guildMemberRepository.LoadGuildMembers();
        }

        public List<GuildMember> GenerateGuildMembers(int count)
        {
            var guildMembers = new List<GuildMember>();
            for (int i = 0; i < count; i++)
            {
                guildMembers.Add(new GuildMember
                {
                    NameDauntless = $"DauntlessName{i}",
                    NameDiscord = $"DiscordName{i}",
                    Status = "Active",
                    Comment = $"Comment{i}"
                });
            }
            return guildMembers;
        }
    }
}
