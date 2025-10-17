using Profile.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Profile.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Github { get; set; }
        public string Technologies { get; set; }

        public Project(string name, string description, string github, string technologies)
        {
            this.Name = name;
            this.Description = description;
            this.Github = github;
            this.Technologies = technologies;
        }
    }
}
