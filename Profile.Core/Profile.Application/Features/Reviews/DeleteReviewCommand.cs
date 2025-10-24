using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Reviews
{
    public class DeleteReviewCommand
    {
        private readonly IProfileDbContext _context;
        public DeleteReviewCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid id)
        {
            var result = await this._context.Reviews.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (result is null)
                return Result<bool>.Fail("Error while deleting the review.");
            
            this._context.Reviews.Remove(result);
            await this._context.SaveChangesAsync(default);

            return Result<bool>.Ok(true);
        }
    }
}
