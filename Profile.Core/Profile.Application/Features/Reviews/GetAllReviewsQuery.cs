using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Reviews
{
    public class GetAllReviewsQuery
    {
        private readonly IProfileDbContext _context;

        public GetAllReviewsQuery(IProfileDbContext context) => this._context = context;

        public async Task<Result<List<Review>>> Handle()
        {
            var reviews = await this._context.Reviews.OrderByDescending(x => x.Date).ToListAsync();

            return Result<List<Review>>.Ok(reviews);
        }
    }
}
