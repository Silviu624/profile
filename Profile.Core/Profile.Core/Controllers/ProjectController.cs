using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profile.Application.Features.Projects;

namespace Profile.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] GetAllProjectsQuery query)
        {
            var result = await query.Handle();
            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        public record CreateProjectDto(string Name, string Description, string Github, string Technologies);
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateProjectCommand cmd, [FromBody] CreateProjectDto dto)
        {
            var result = await cmd.Handle(dto.Name, dto.Description, dto.Github, dto.Technologies);
            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromServices] DeleteProjectCommand cmd, Guid id, CancellationToken ct)
        {
            var result = await cmd.Handle(id, ct);
            return result.Succces ? NoContent() : NotFound(result.Error);
        }

        public record UpdateProjectDto(string Name, string Description, string Github, string Technologies);
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromServices] UpdateProjectCommand cmd, Guid id, [FromBody] UpdateProjectDto dto, CancellationToken ct)
        {
            var result = await cmd.Handle(id, dto.Name, dto.Description, dto.Github, dto.Technologies, ct);
            return result.Succces ? NoContent() : Problem(result.Error);
        }
    }
}
