using Profile.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string ReviewComment { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Review(string reviewComment, string name, DateTime date)
        {
            this.ReviewComment = reviewComment;
            this.Name = name;
            this.Date = date;
        }
    }
}
