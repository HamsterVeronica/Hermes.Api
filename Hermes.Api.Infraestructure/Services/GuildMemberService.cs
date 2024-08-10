using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.Contracts.Service;
using Hermes.Api.Domain.Model;

namespace Hermes.Api.Infraestructure.Services
{
    public class GuildMemberService : IGuildMemberService
    {
        private readonly IGuildMemberRepository _guildMemberRepository;

        public GuildMemberService(IGuildMemberRepository guildMemberRepository)
        {
            _guildMemberRepository = guildMemberRepository;
        }

        public void SaveGuildMembers(List<GuildMember> members)
        {
            _guildMemberRepository.SaveGuildMembers(members);
        }

        public List<GuildMember> LoadGuildMembers()
        {
            return _guildMemberRepository.LoadGuildMembers();
        }

        public List<GuildMember> GenerateGuildMembers(int count)
        {
            var members = new List<GuildMember>();
            for (int i = 0; i < count; i++)
            {
                members.Add(new GuildMember
                {
                    Id = i,
                    NameDauntless = $"Member{i}",
                    NameDiscord = $"Discord{i}",
                    Status = "Active",
                    Comment = $"Comment{i}"
                });
            }
            return members;
        }

        public GuildMember GetGuildMemberById(int id)
        {
            return _guildMemberRepository.LoadGuildMembers().FirstOrDefault(m => m.Id == id);
        }

        public void CreateGuildMember(GuildMember member)
        {
            var members = _guildMemberRepository.LoadGuildMembers();
            if (members.Count >= 100)
            {
                throw new System.Exception("Member limit reached");
            }

            member.Id = members.Any() ? members.Max(m => m.Id) + 1 : 1;
            members.Add(member);
            SaveGuildMembers(members);
        }

        public void CreateGuildMembers(List<GuildMember> newMembers)
        {
            var members = _guildMemberRepository.LoadGuildMembers();
            if (members.Count + newMembers.Count > 100)
            {
                throw new System.Exception("Member limit reached");
            }

            int nextId = members.Any() ? members.Max(m => m.Id) + 1 : 1;
            foreach (var member in newMembers)
            {
                member.Id = nextId++;
                members.Add(member);
            }
            SaveGuildMembers(members);
        }

        public void UpdateGuildMember(GuildMember member)
        {
            var members = _guildMemberRepository.LoadGuildMembers();
            var existingMember = members.FirstOrDefault(m => m.Id == member.Id);
            if (existingMember != null)
            {
                existingMember.NameDauntless = member.NameDauntless;
                existingMember.NameDiscord = member.NameDiscord;
                existingMember.Status = member.Status;
                existingMember.Comment = member.Comment;
                SaveGuildMembers(members);
            }
        }

        public void DeleteGuildMember(int id)
        {
            var members = _guildMemberRepository.LoadGuildMembers();
            var memberToDelete = members.FirstOrDefault(m => m.Id == id);
            if (memberToDelete != null)
            {
                members.Remove(memberToDelete);
                SaveGuildMembers(members);
            }
        }
    }
}
