using Profile.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class Experience : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }

        public Experience (string companyName, string role, DateTime startDate, DateTime endDate, string description, string technologies)
        {
            this.CompanyName = companyName;
            this.Role = role;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
            this.Technologies = technologies;
        }
    }
}
