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
    public class UpdateProjectCommand
    {
        private readonly IProfileDbContext _context;

        public UpdateProjectCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid projectId, string name, string description, string github, string technologies, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result<bool>.Fail("Project name is required.");

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId, ct);

            if (project == null)
                return Result<bool>.Fail("Project not found.");

            // Apply updates
            project.Name = name;
            project.Description = description;
            project.Github = github;
            project.Technologies = technologies;

            // No need to call Update() unless using AsNoTracking or detached entity
            await _context.SaveChangesAsync(ct);

            return Result<bool>.Ok(true);
        }

    }
}
