using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Reviews
{
    public class CreateReviewCommand
    {
        private readonly IProfileDbContext _context;

        public CreateReviewCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<Guid>> Handle(string reviewComment, string name, DateTime date)
        {
            if (name is null || reviewComment is null) return Result<Guid>.Fail("Name and comment are required.");

            Review review = new Review(reviewComment, name, date);
            this._context.Reviews.Add(review);

            await this._context.SaveChangesAsync(default);

            return Result<Guid>.Ok(review.Id);
        }
    }
}
