using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Projects
{
    public class DeleteProjectCommand
    {
        private readonly IProfileDbContext _context;

        public DeleteProjectCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid projectId, CancellationToken ct = default)
        {
            var project = await this._context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);

            if (project is null) return Result<bool>.Fail("Project not found.");

            this._context.Projects.Remove(project);
            await _context.SaveChangesAsync(ct);

            return Result<bool>.Ok(true);
        }
    }
}
