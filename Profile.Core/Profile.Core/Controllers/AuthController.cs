using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Profile.Application.Features.Auth;
using Profile.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Core.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IProfileDbContext _context;
        public AuthController(IConfiguration config, IProfileDbContext context) {
            this._config = config;
            this._context = context;
        }

        public record UserDto(string Email, string Password, string Role = "Admin");

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromServices] CreateAuthUserCommand cmd, [FromBody] UserDto dto)
        {
            if (_context.Users.Count() > 0)
            {
                var user = _context.Users.Where(x => x.Email == dto.Email && x.PasswordHash == dto.Password).FirstOrDefault();

                if (user != null)
                {
                    var jwt = _config.GetSection("Jwt");
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, dto.Email),
                        new Claim(ClaimTypes.Name, dto.Email),
                        new Claim(ClaimTypes.Role, dto.Role)
                    };

                    var token = new JwtSecurityToken(
                        issuer: jwt["Issuer"],
                        audience: jwt["Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(int.Parse(jwt["ExpiresMinutes"]!)),
                        signingCredentials: creds);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else return Problem("No user with this email and password exists.");
            }
            else
            {
                if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                    return Problem("Email/Password are required.");

                if (_context.Users.Count() > 0) return Unauthorized("Only one user can be created.");

                var result = await cmd.Handle(dto.Email, dto.Password, dto.Role);

                return result.Succces ? Ok(result.Value) : Problem(result.Error);
            }
        }
    }
}
