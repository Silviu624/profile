using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profile.Application.Features.Educations;

namespace Profile.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] GetAllEducationsQuery query)
        {
            var result = await query.Handle();
            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        public record EducationDto(string institutionName, string degree, string fieldOfStudy, DateTime startDate, DateTime endDate, string description);
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateEducationCommand cmd, [FromBody]EducationDto dto)
        {
            var result = await cmd.Handle(dto.institutionName, dto.degree, dto.fieldOfStudy, dto.startDate, dto.endDate, dto.description);

            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromServices]UpdateEducationCommand cmd, [FromBody]EducationDto dto, Guid id)
        {
            var result = await cmd.Handle(id, dto.institutionName, dto.degree, dto.fieldOfStudy, dto.startDate, dto.endDate, dto.description);

            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromServices]DeleteEducationCommand cmd, Guid id)
        {
            var result = await cmd.Handle(id);

            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }
    }
}
