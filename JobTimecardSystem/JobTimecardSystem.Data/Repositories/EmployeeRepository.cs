using System;
using System.Collections.Generic;
using System.Text;
using JobTimecardSystem.Data.Models;
using NHibernate;

namespace JobTimecardSystem.Data.Repositories
{
    public class EmployeeRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public EmployeeRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Employee> GetAll(string? search = null)
        {
            using var session = _sessionFactory.OpenSession();
            var employees = session.Query<Employee>().ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                employees = employees.Where(e =>
                    e.EmployeeCode.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    e.FirstName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    e.LastName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    e.Role.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    e.Email.Contains(term, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
        }

        public Employee? GetById(int id)
        {
            using var session = _sessionFactory.OpenSession();
            return session.Get<Employee>(id);
        }

        public Employee Add(Employee employee)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Save(employee);
            tx.Commit();
            return employee;
        }

        public void Update(Employee employee)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Update(employee);
            tx.Commit();
        }

        public bool Delete(int id)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            var employee = session.Get<Employee>(id);
            if (employee == null) return false;
            session.Delete(employee);
            tx.Commit();
            return true;
        }
    }
}