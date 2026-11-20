using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using JobTimecardSystem.Data.Models;

namespace JobTimecardSystem.Data.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.EmployeeCode).Not.Nullable().Length(30);
            Map(x => x.FirstName).Not.Nullable().Length(80);
            Map(x => x.LastName).Not.Nullable().Length(80);
            Map(x => x.Role).Not.Nullable().Length(80);
            Map(x => x.Email).Length(150);
        }
    }
}