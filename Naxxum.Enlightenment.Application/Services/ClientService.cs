using Naxxum.Enlightenment.Application.Abstractions;
using Naxxum.Enlightenment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.Enlightenment.Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client CreateMovie(Client movie)
        {
            _clientRepository.Add(movie);
            return movie;
        }

       /* public List<Client> GetAllMovies()
        {
            var movies = _clientRepository.();
            return movies;
        }*/




    }
}
