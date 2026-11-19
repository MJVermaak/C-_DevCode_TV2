using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using JobTimecardSystem.Data.Models;


namespace JobTimecardSystem.Data.Mappings
{
    public class JobMap : ClassMap<Job>
    {
        public JobMap()
        {
            Table("Jobs");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.JobNumber)
                .Not.Nullable()
                .Unique()
                .Length(50);

            Map(x => x.JobType)
                .CustomType<JobType>()
                .Not.Nullable()
                .Length(20);

            Map(x => x.JobDate)
                .Not.Nullable();

            // Client Information columns
            Map(x => x.CompanyName)
                .Not.Nullable()
                .Length(150);

            Map(x => x.ContactName)
                .Not.Nullable()
                .Length(100);

            Map(x => x.TelephoneNumber)
                .Not.Nullable()
                .Length(30);
        }

    }
}
