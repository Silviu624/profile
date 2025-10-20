using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using Profile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Persons
{
    public class GetPersonQuery
    {
        private readonly IProfileDbContext _context;

        public GetPersonQuery(IProfileDbContext context) => this._context = context;

        public async Task<Result<Person>> Handle()
        {
            var person = await this._context.Persons.SingleAsync();

            if (person != null) return Result<Person>.Ok(person);
            else return Result<Person>.Fail("Error in getting the person information.");
        }
    }
}
