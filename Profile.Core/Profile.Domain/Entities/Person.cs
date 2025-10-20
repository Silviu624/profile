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
        public int Age { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Skills { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string Instagram { get; set; }

        public Person(Guid id, string name, int age, string title, string email, string address, string about, string skills, string phoneNumber, string linkedIn, string instagram)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Title = title;
            this.Email = email;
            this.Address = address;
            this.About = about;
            this.Skills = skills;
            this.PhoneNumber = phoneNumber;
            this.LinkedIn = linkedIn;
            this.Instagram = instagram;
        }

    }
}
