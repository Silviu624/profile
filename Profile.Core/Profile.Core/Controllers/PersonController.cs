using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profile.Application.Features.Persons;

namespace Profile.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPerson([FromServices] GetPersonQuery query)
        {
            var result = await query.Handle();
            return result.Succces ? Ok(result.Value) : Problem("No person found.");
        }

        public record UpdatePersonDto(string name, int age, string title, string email, string address, string about, string skills, string phoneNumber, string linkedIn, string instagram);
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromServices] UpdatePersonCommand cmd, Guid id, [FromBody] UpdatePersonDto dto, CancellationToken ct)
        {
            var result = await cmd.Handle(id, dto.name, dto.age, dto.title, dto.email, dto.address, dto.about, dto.skills, dto.phoneNumber, dto.linkedIn, dto.instagram, ct);
            return result.Succces ? NoContent() : Problem(result.Error);
        }
    }
}
