using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using JobTimecardSystem.Data.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace JobTimecardSystem.Data.Repositories
{
    public static class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString)
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JobMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }
    }
}