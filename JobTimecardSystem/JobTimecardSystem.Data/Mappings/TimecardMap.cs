using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using JobTimecardSystem.Data.Models;

namespace JobTimecardSystem.Data.Mappings
{
    public class TimecardMap : ClassMap<Timecard>
    {
        public TimecardMap()
        {
            Table("Timecards");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Employee)
                .Not.Nullable()
                .Length(100);

            Map(x => x.DateWorked)
                .Not.Nullable();

            Map(x => x.HoursWorked)
                .Not.Nullable()
                .Precision(5)
                .Scale(2);

            Map(x => x.JobId)
                .Column("JobId")
                .Not.Nullable();

            References(x => x.Job)
                .Column("JobId")
                .Not.Insert()
                .Not.Update()
                .Fetch.Join();
        }
    }
}
