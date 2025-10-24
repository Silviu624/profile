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
    public class CreateExperienceCommand
    {
        private readonly IProfileDbContext _context;
        public CreateExperienceCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<Guid>> Handle(string companyName, string role, DateTime startDate, DateTime endDate, string description, string technologies)
        {
            var experience = new Experience(companyName, role, startDate, endDate, description, technologies);

            this._context.Experiences.Add(experience);
            await this._context.SaveChangesAsync(default);

            return Result<Guid>.Ok(experience.Id);
        }
    }
}
