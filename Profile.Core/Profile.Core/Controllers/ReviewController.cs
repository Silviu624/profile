using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profile.Application.Features.Reviews;

namespace Profile.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] GetAllReviewsQuery query)
        {
            var result = await query.Handle();
            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        public record ReviewDto(string reviewComment, string name, DateTime date);
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateReviewCommand cmd, [FromBody] ReviewDto dto)
        {
            var result = await cmd.Handle(dto.reviewComment, dto.name, dto.date);
            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromServices] DeleteReviewCommand cmd, Guid id)
        {
            var result = await cmd.Handle(id);
            return result.Succces ? Ok(result.Value) : Problem(result.Error);
        }
    }
}
