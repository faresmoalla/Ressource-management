using Naxxum.Enlightenment.Application.Abstractions;
using Naxxum.Enlightenment.Domain.Entities;
using Naxxum.Enlightenment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.Enlightenment.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appdbContext ;

        public ClientRepository(AppDbContext appDbContext)
        {
            _appdbContext = appDbContext;
        }

        public void Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Client, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Client CreateClient(Client client)
        {
            _appdbContext.Client.Add(client);
            _appdbContext.SaveChanges();
            return client;
        }



        public List<Client> GetAllMovies()
        {
            return _appdbContext.Client.ToList();
        }

        public void Remove(Client entity)
        {
            throw new NotImplementedException();
        }

        public Client UpdateClient(Client client)
        {
            var result = _appdbContext.Update(client);
            _appdbContext.SaveChanges();
            return result.Entity;
        }
      

      
    }
}

