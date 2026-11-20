using System;
using System.Collections.Generic;
using System.Text;

namespace JobTimecardSystem.Data.Models
{
    namespace JobTimecardSystem.Data.Models
    {
        public class Client
        {
            public virtual int Id { get; set; }
            public virtual string CompanyName { get; set; } = string.Empty;
            public virtual string ContactName { get; set; } = string.Empty;
            public virtual string TelephoneNumber { get; set; } = string.Empty;
        }
    }
}
