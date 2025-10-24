using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Experiences
{
    public class DeleteExperienceCommand
    {
        private readonly IProfileDbContext _context;

        public DeleteExperienceCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid id)
        {
            var experience = await this._context.Experiences.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (experience is null) return Result<bool>.Fail("Delete failed. Experience was not found.");

            this._context.Experiences.Remove(experience);
            await this._context.SaveChangesAsync(default);

            return Result<bool>.Ok(true);
        }
    }
}
