using System;
using System.Collections.Generic;
using System.Text;

namespace JobTimecardSystem.Data.Models
{
    public class Job
    {
        public virtual int Id { get; set; }
        public virtual string JobNumber { get; set; } = string.Empty;
        public virtual JobType JobType { get; set; }
        public virtual DateTime JobDate { get; set; } = DateTime.Today;

        public virtual string CompanyName { get; set; } = string.Empty;
        public virtual string ContactName { get; set; } = string.Empty;
        public virtual string TelephoneNumber { get; set; } = string.Empty;
}
}