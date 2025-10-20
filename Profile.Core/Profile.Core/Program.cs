using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Profile.Application.Features.Auth;
using Profile.Application.Features.Persons;
using Profile.Application.Features.Projects;
using Profile.Application.Interfaces;
using Profile.Infrastructure;
using System.Text;

namespace Profile.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddCors(options => options.AddPolicy("profile", p =>
                p.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()));

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddScoped<GetAllProjectsQuery>();
            builder.Services.AddScoped<CreateProjectCommand>();
            builder.Services.AddScoped<UpdateProjectCommand>();
            builder.Services.AddScoped<DeleteProjectCommand>();
            builder.Services.AddScoped<CreateAuthUserCommand>();
            builder.Services.AddScoped<GetPersonQuery>();
            builder.Services.AddScoped<UpdatePersonCommand>();

            var jwt = builder.Configuration.GetSection("Jwt");
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwt["Issuer"],
                        ValidAudience = jwt["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!))
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            //app.UseAuthorization();
            app.UseCors("profile");
            app.MapControllers();

            app.Run();
        }
    }
}
