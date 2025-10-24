using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Educations
{
    public class CreateEducationCommand
    {
        private readonly IProfileDbContext _context;
        public CreateEducationCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<Guid>> Handle(string institutionName, string degree, string fieldOfStudy, DateTime startDate, DateTime endDate, string description)
        {
            var education = new Education(institutionName, degree, fieldOfStudy, startDate, endDate, description);

            this._context.Educations.Add(education);
            await this._context.SaveChangesAsync(default);

            return Result<Guid>.Ok(education.Id);
        }
    }
}
