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
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Github { get; private set; }
        public string Technologies { get; private set; }

        public Project(string name, string description, string github, string technologies)
        {
            this.Name = name;
            this.Description = description;
            this.Github = github;
            this.Technologies = technologies;
        }
    }
}
