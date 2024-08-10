using Hermes.Api.Domain.Contracts.Service;
using Hermes.Api.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Api.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GuildMemberController : ControllerBase
    {
        private readonly IGuildMemberService _guildMemberService;

        public GuildMemberController(IGuildMemberService guildMemberService)
        {
            _guildMemberService = guildMemberService;
        }

        [HttpGet]
        public IActionResult GetGuildMembers()
        {
            var members = _guildMemberService.LoadGuildMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public IActionResult GetGuildMemberById(int id)
        {
            var member = _guildMemberService.GetGuildMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public IActionResult CreateGuildMember([FromBody] GuildMember member)
        {
            _guildMemberService.CreateGuildMember(member);
            return CreatedAtAction(nameof(GetGuildMemberById), new { id = member.Id }, member);
        }

        [HttpPost("batch")]
        public IActionResult CreateGuildMembers([FromBody] List<GuildMember> members)
        {
            _guildMemberService.CreateGuildMembers(members);
            return Ok(members);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGuildMember(int id, [FromBody] GuildMember updatedMember)
        {
            updatedMember.Id = id;
            _guildMemberService.UpdateGuildMember(updatedMember);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuildMember(int id)
        {
            _guildMemberService.DeleteGuildMember(id);
            return NoContent();
        }
    }
}
