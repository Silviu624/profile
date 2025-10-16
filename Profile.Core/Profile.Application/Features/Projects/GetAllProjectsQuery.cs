using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Projects
{
    internal class GetAllProjectsQuery
    {
        private readonly IProfileDbContext _context;
        public GetAllProjectsQuery(IProfileDbContext context) => this._context = context;

        public async Task<Result<List<Project>>> Handle()
        {
            var projects = await _context.Projects.OrderBy(p => p.Id).ToListAsync();

            return Result<List<Project>>.Ok(projects);
        }
    }
}
