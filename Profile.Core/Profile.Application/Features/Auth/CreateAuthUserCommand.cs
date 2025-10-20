using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Auth
{
    public class CreateAuthUserCommand
    {
        private readonly IProfileDbContext _context;

        public CreateAuthUserCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(string email, string passwordHash, string role)
        {
            var user = new User(email, passwordHash, role);

            this._context.Users.Add(user);

            await this._context.SaveChangesAsync(default);

            return Result<bool>.Ok(true);
        }
    }
}
