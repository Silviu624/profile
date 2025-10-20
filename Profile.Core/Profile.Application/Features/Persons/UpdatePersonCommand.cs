using Microsoft.EntityFrameworkCore;
using Profile.Application.Common;
using Profile.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Application.Features.Persons
{
    public class UpdatePersonCommand
    {
        private readonly IProfileDbContext _context;

        public UpdatePersonCommand(IProfileDbContext context) => this._context = context;

        public async Task<Result<bool>> Handle(Guid personId, string name, int age, string title, string email, string address, string about, string skills, string phoneNumber, string linkedIn, string instagram, CancellationToken ct)
        {
            var person = await this._context.Persons.FirstOrDefaultAsync(x => x.Id == personId);

            if (person == null)
                return Result<bool>.Fail("No person was found");

            person.Name = name;
            person.Age = age;
            person.Title = title;
            person.Email = email;
            person.Address = address;
            person.About = about;
            person.Skills = skills;
            person.PhoneNumber = phoneNumber;
            person.LinkedIn = linkedIn;
            person.Instagram = instagram;

            await this._context.SaveChangesAsync(ct);

            return Result<bool>.Ok(true);
        }
    }
}
