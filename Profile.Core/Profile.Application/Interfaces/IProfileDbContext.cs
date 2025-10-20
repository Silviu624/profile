using Microsoft.EntityFrameworkCore;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Interfaces
{
    public interface IProfileDbContext
    {
        DbSet<Person> Persons { get; }
        DbSet<Experience> Experiences { get; }
        DbSet<Education> Educations { get; }
        DbSet<Project> Projects { get; }
        DbSet<Review> Reviews { get; }
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
