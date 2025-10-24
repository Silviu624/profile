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
    public class DeleteEducationCommand
    {
        private readonly IProfileDbContext _context;
        public DeleteEducationCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid id)
        {
            var education = await this._context.Educations.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (education is null) return Result<bool>.Fail("Education was not found");
            this._context.Educations.Remove(education);
            await this._context.SaveChangesAsync(default);

            return Result<bool>.Ok(true);
        }
    }
}
