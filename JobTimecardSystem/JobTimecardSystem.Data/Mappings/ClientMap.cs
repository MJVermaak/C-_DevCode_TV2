using FluentNHibernate.Mapping;
using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Models.JobTimecardSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTimecardSystem.Data.Mappings
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Table("Clients");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.CompanyName).Not.Nullable().Length(150);
            Map(x => x.ContactName).Not.Nullable().Length(100);
            Map(x => x.TelephoneNumber).Not.Nullable().Length(30);
        }
    }
}
