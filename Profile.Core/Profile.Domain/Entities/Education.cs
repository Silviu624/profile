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
        public string InstitutionName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public Education(string institutionName, string degree, string fieldOfStudy, DateTime startDate, DateTime endDate, string description)
        {
            this.InstitutionName = institutionName;
            this.Degree = degree;
            this.FieldOfStudy = fieldOfStudy;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
        }
    }
}
