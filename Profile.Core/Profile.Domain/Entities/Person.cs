using Profile.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Title { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string About { get; private set; }
        public string Skills { get; private set; }
        public string PhoneNumber { get; private set; }
        public string LinkedIn { get; private set; }
        public string Instagram { get; private set; }

        public Person(string name, int age, string title, string email, string address, string about, string skills, string phoneNumber, string linkedin, string instagram)
        {
            this.Name = name;
            this.Age = age;
            this.Title = title;
            this.Email = email;
            this.Address = address;
            this.About = about;
            this.Skills = skills;
            this.PhoneNumber = phoneNumber;
            this.LinkedIn = linkedin;
            this.Instagram = instagram;
        }

    }
}
