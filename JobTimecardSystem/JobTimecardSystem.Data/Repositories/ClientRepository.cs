using JobTimecardSystem.Data.Models;
using JobTimecardSystem.Data.Models.JobTimecardSystem.Data.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTimecardSystem.Data.Repositories
{
    public class ClientRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public ClientRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Client> GetAll(string? search = null)
        {
            using var session = _sessionFactory.OpenSession();
            var clients = session.Query<Client>().ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                clients = clients.Where(c =>
                    c.CompanyName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    c.ContactName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    c.TelephoneNumber.Contains(term, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return clients.OrderBy(c => c.CompanyName).ToList();
        }

        public Client? GetById(int id)
        {
            using var session = _sessionFactory.OpenSession();
            return session.Get<Client>(id);
        }

        public Client Add(Client client)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Save(client);
            tx.Commit();
            return client;
        }

        public void Update(Client client)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Update(client);
            tx.Commit();
        }

        public bool Delete(int id)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            var client = session.Get<Client>(id);
            if (client == null) return false;
            session.Delete(client);
            tx.Commit();
            return true;
        }
    }
}