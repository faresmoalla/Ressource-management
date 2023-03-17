using Naxxum.Enlightenment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.Enlightenment.Application.Abstractions
{
    public interface IClientRepository :  IRepository<Client>
    {
        public Client UpdateClient(Client client);
        public List<Client> GetAllMovies();



    }
}
