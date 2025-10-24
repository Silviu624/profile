using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Educations
{
    public class UpdateEducationCommand
    {
        private readonly IProfileDbContext _context;
        public UpdateEducationCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid id, string institutionName, string degree, string fieldOfStudy, DateTime startDate, DateTime endDate, string description)
        {
            var education = await this._context.Educations.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (education is null) return Result<bool>.Fail("Education item was not found.");

            education.InstitutionName = institutionName;
            education.Degree = degree;
            education.FieldOfStudy = fieldOfStudy;
            education.StartDate = startDate;
            education.EndDate = endDate;
            education.Description = description;

            await this._context.SaveChangesAsync(default);

            return Result<bool>.Ok(true);
        }
    }
}
