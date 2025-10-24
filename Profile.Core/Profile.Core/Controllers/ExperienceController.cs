using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profile.Application.Features.Experiences;
using Profile.Domain.Entities;

namespace Profile.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] GetAllExperiencesQuery query)
        {
            var result = await query.Handle();
            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        public record ExperienceDto(string companyName, string role, DateTime startDate, DateTime endDate, string description, string technologies);
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateExperienceCommand cmd, [FromBody] ExperienceDto dto)
        {
            var result = await cmd.Handle(dto.companyName, dto.role, dto.startDate, dto.endDate, dto.description, dto.technologies);

            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromServices] UpdateExperienceCommand cmd, ExperienceDto dto, Guid id)
        {
            var result = await cmd.Handle(id, dto.companyName, dto.role, dto.startDate, dto.endDate, dto.description, dto.technologies);

            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromServices] DeleteExperienceCommand cmd, Guid id)
        {
            var result = await cmd.Handle(id);

            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }
    }
}
