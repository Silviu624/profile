using Profile.Application.Interfaces;
using Profile.Infrastructure;
using Profile.Application.Features.Projects;

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

            var app = builder.Build();

            app.UseHttpsRedirection();
            //app.UseAuthorization();
            app.UseCors("profile");
            app.MapControllers();

            app.Run();
        }
    }
}
