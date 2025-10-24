using Microsoft.EntityFrameworkCore;
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
    public class GetAllEducationsQuery
    {
        private readonly IProfileDbContext _context;
        public GetAllEducationsQuery(IProfileDbContext context) => this._context = context;

        public async Task<Result<List<Education>>> Handle()
        {
            var educations = await this._context.Educations.OrderByDescending(x => x.StartDate).ToListAsync();

            return Result<List<Education>>.Ok(educations);
        }
    }
}
