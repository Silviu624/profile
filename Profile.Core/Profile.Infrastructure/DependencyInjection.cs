using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profile.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("ProfileDB");

            services.AddDbContext<ProfileDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IProfileDbContext>(sp => sp.GetRequiredService<ProfileDbContext>());



            return services;
        }
    }
}
