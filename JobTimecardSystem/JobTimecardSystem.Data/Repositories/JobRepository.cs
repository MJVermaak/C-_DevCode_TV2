using System;
using System.Collections.Generic;
using System.Text;
using JobTimecardSystem.Data.Models;
using NHibernate;

namespace JobTimecardSystem.Data.Repositories
{
    public class JobRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public JobRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Job> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            return session.Query<Job>()
                .OrderByDescending(j => j.JobDate)
                .ToList();
        }

        public Job? GetById(int id)
        {
            using var session = _sessionFactory.OpenSession();
            return session.Get<Job>(id);
        }

        public bool JobNumberExists(string jobNumber, int? excludeId = null)
        {
            using var session = _sessionFactory.OpenSession();
            return session.Query<Job>().Any(j =>
                j.JobNumber.ToLower() == jobNumber.Trim().ToLower() &&
                (!excludeId.HasValue || j.Id != excludeId.Value));
        }

        public Job Add(Job job)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Save(job);
            tx.Commit();
            return job;
        }

        public void Update(Job job)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Update(job);
            tx.Commit();
        }

        public bool Delete(int id)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            var job = session.Get<Job>(id);
            if (job == null) return false;

            session.Delete(job);
            tx.Commit();
            return true;
        }
    }
}