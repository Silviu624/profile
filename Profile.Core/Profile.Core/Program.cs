using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Profile.Application.Features.Auth;
using Profile.Application.Features.Persons;
using Profile.Application.Features.Projects;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
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

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ProfileDbContext>();
                context.Database.EnsureCreated();

                if(!context.Persons.Any())
                {
                    context.Persons.Add(new Person
                    {
                        Id = Guid.NewGuid(),
                        Name = "~to be edited~",
                        DateOfBirth = new DateTime(1990, 1, 1),
                        Title = "~to be edited~",
                        Email = "~to be edited~",
                        Address = "~to be edited~",
                        About = "~to be edited~",
                        Skills = "~to be edited~",
                        PhoneNumber = "~to be edited~",
                        LinkedIn = "~to be edited~",
                        Instagram = "~to be edited~",
                        Nationality = "~to be edited~"
                    });

                    context.SaveChanges();
                }
            }

            app.Run();
        }
    }
}
