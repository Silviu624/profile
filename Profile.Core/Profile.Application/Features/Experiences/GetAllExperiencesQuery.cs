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
    public class GetAllExperiencesQuery
    {
        private readonly IProfileDbContext _context;
        public GetAllExperiencesQuery(IProfileDbContext context) => this._context = context;

        public async Task<Result<List<Experience>>> Handle()
        {
            var experiences = await this._context.Experiences.OrderByDescending(exp => exp.StartDate).ToListAsync();
            return Result<List<Experience>>.Ok(experiences);
        }
    }
}
