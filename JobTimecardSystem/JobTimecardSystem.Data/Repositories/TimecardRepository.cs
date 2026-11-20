using System;
using System.Collections.Generic;
using System.Text;
using JobTimecardSystem.Data.Models;
using NHibernate;
using NHibernate.Linq;

namespace JobTimecardSystem.Data.Repositories
{
    public class TimecardRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public TimecardRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Timecard> GetAll(string? search = null)
        {
            using var session = _sessionFactory.OpenSession();
            var timecards = session.Query<Timecard>()
                .Fetch(t => t.Job)
                .ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                timecards = timecards.Where(t =>
                    t.Employee.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    (t.Job != null && t.Job.JobNumber.Contains(term, StringComparison.OrdinalIgnoreCase)) ||
                    (t.Job != null && t.Job.CompanyName.Contains(term, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            return timecards.OrderByDescending(t => t.DateWorked).ToList();
        }
        public Timecard? GetById(int id)
        {
            using var session = _sessionFactory.OpenSession();
            return session.Get<Timecard>(id);
        }

        public decimal GetTotalHoursForEmployeeOnDate(string employee, DateTime date, int? excludeId = null)
        {
            using var session = _sessionFactory.OpenSession();
            var targetDate = date.Date;

            return session.Query<Timecard>()
                .Where(t => t.Employee.ToLower() == employee.Trim().ToLower()
                         && t.DateWorked.Date == targetDate
                         && (!excludeId.HasValue || t.Id != excludeId.Value))
                .Sum(t => (decimal?)t.HoursWorked) ?? 0m;
        }

        public Timecard Add(Timecard timecard)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Save(timecard);
            tx.Commit();

            // Reload so the associated Job details are populated
            return GetById(timecard.Id) ?? timecard;
        }

        public Timecard? Update(Timecard timecard)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Update(timecard);
            tx.Commit();

            return GetById(timecard.Id);
        }

        public bool Delete(int id)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            var timecard = session.Get<Timecard>(id);
            if (timecard == null) return false;

            session.Delete(timecard);
            tx.Commit();
            return true;
        }
    }
}
