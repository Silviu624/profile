using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Experiences
{
    public class UpdateExperienceCommand
    {
        private readonly IProfileDbContext _context;
        public UpdateExperienceCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid id, string companyName, string role, DateTime startDate, DateTime endDate, string description, string technologies)
        {
            var experience = await this._context.Experiences.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (experience == null) return Result<bool>.Fail("This work experience is not found.");

            experience.CompanyName = companyName;
            experience.Role = role;
            experience.StartDate = startDate;
            experience.EndDate = endDate;
            experience.Description = description;
            experience.Technologies = technologies;

            await this._context.SaveChangesAsync(default);

            return Result<bool>.Ok(true);
        }
    }
}
