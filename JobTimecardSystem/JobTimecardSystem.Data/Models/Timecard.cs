using System;
using System.Collections.Generic;
using System.Text;

namespace JobTimecardSystem.Data.Models
{
    public class Timecard
    {
        public virtual int Id { get; set; }
        public virtual string Employee { get; set; } = string.Empty;
        public virtual DateTime DateWorked { get; set; } = DateTime.Today;
        public virtual decimal HoursWorked { get; set; }

        public virtual int JobId { get; set; }
        public virtual Job? Job { get; set; }
    }
}
