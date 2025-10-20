using Microsoft.EntityFrameworkCore;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Infrastructure
{
    public class ProfileDbContext: DbContext, IProfileDbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base (options) { }

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<Experience> Experiences => Set<Experience>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(p =>
            {
                p.Property(x => x.Id);
                p.Property(x => x.Name).IsRequired().HasMaxLength(200);
                p.Property(x => x.Instagram).HasMaxLength(200);
                p.Property(x => x.LinkedIn).HasMaxLength(200);
                p.Property(x => x.PhoneNumber).HasMaxLength(50);
                p.Property(x => x.Skills).HasMaxLength(200);
                p.Property(x => x.Title).HasMaxLength(200);
                p.Property(x => x.About).HasMaxLength(2000);
                p.Property(x => x.Age).HasMaxLength(10).IsRequired();
                p.Property(x => x.Address).HasMaxLength(200);
                p.Property(x => x.Email).HasMaxLength(320); 
                p.Property(x => x.Skills).HasMaxLength(200);
            });

            modelBuilder.Entity<Education>(e =>
            {
                e.Property(x => x.Id);
                e.Property(x => x.FieldOfStudy).HasMaxLength(300);
                e.Property(x => x.Degree).HasMaxLength(200);
                e.Property(x => x.Description).HasMaxLength(2000);
                e.Property(x => x.EndDate);
                e.Property(x => x.StartDate);
                e.Property(x => x.InstitutionName).HasMaxLength(500);
            });

            modelBuilder.Entity<Experience>(e =>
            {
                e.Property(x => x.Id);
                e.Property(x => x.CompanyName).HasMaxLength(300);
                e.Property(x => x.Role).HasMaxLength(200);
                e.Property(x => x.Description).HasMaxLength(2000);
                e.Property(x => x.EndDate);
                e.Property(x => x.StartDate);
                e.Property(x => x.Technologies).HasMaxLength(500);
            });

            modelBuilder.Entity<Project>(p =>
            {
                p.Property(x => x.Id);
                p.Property(x => x.Name).HasMaxLength(300);
                p.Property(x => x.Github).HasMaxLength(300);
                p.Property(x => x.Description).HasMaxLength(2000);
                p.Property(x => x.Technologies).HasMaxLength(500);
            });

            modelBuilder.Entity<Review>(p =>
            {
                p.Property(x => x.Id);
                p.Property(x => x.Name).HasMaxLength(300);
                p.Property(x => x.Date);
                p.Property(x => x.ReviewComment).HasMaxLength(2000);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.Property(x => x.Email).HasMaxLength(300).IsRequired();
                u.Property(x => x.PasswordHash).HasMaxLength(200).IsRequired();
                u.Property(x => x.Role).HasMaxLength(50).IsRequired();
            });

            base.OnModelCreating(modelBuilder);

            var personId = Guid.Parse("5103E5E5-D93F-4A6E-91E8-202DC42162B0");

            modelBuilder.Entity<Person>().HasData(new Person(
                id: personId,
                name: "~to be edited~",
                age: 0,
                title: "~to be edited~",
                email: "~to be edited~",
                address: "~to be edited~",
                about: "~to be edited~",
                skills: "~to be edited~",
                phoneNumber: "~to be edited~",
                linkedIn: "~to be edited~",
                instagram: "~to be edited~"));
        }
    }
}
