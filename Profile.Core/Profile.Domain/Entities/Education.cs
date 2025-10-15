using Profile.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class Education : BaseEntity
    {
        public string InstitutionName { get; private set; }
        public string Degree { get; private set; }
        public string FieldOfStudy { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Description { get; private set; }

        public Education(string institutionName, string degree, string filedOfStudy, DateTime startDate, DateTime endDate, string description)
        {
            this.InstitutionName = institutionName;
            this.Degree = degree;
            this.FieldOfStudy = filedOfStudy;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }
    }
}
