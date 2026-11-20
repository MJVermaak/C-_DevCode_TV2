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

        public List<Job> GetAll(string? search = null)
        {
            using var session = _sessionFactory.OpenSession();
            var jobs = session.Query<Job>().ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                jobs = jobs.Where(j =>
                    j.JobNumber.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    j.JobType.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    j.CompanyName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    j.ContactName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    j.TelephoneNumber.Contains(term, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return jobs.OrderByDescending(j => j.JobDate).ThenBy(j => j.JobNumber).ToList();
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