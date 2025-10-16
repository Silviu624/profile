using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Projects
{
    public class CreateProjectCommand
    {
        private readonly IProfileDbContext _context;
        public CreateProjectCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<Guid>> Handle(string name, string description, string github, string technologies)
        {
            if (string.IsNullOrEmpty(name)) return Result<Guid>.Fail("Project name is required.");

            var project = new Project(name, description, github, technologies);

            this._context.Projects.Add(project);

            await this._context.SaveChangesAsync(default);

            return Result<Guid>.Ok(project.Id);
        }
    }
}
