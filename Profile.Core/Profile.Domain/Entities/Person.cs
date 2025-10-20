using Profile.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class Person 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Skills { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string Instagram { get; set; }
        public string Nationality { get; set; }

        public Person() { }

        public Person(Guid id, string name, DateTime dateOfBirth, string title, string email, string address, string about, string skills, string phoneNumber, string linkedIn, string instagram, string nationality)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Title = title;
            this.Email = email;
            this.Address = address;
            this.About = about;
            this.Skills = skills;
            this.PhoneNumber = phoneNumber;
            this.LinkedIn = linkedIn;
            this.Instagram = instagram;
            this.Nationality = nationality;
        }

    }
}
