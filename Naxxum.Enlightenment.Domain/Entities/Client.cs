using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.Enlightenment.Domain.Entities
{
    public class Client : AggregateRoot

    {
    
        //constructor
        public Client(int idClient, string nom,
            string prenom, string email, string telephone, string adresse,
            DateTime? envoyéLe, DateTime? dateObtentionBac) : base(idClient)
        {
            IdClient = idClient;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            EnvoyéLe = envoyéLe;
            DateObtentionBac = dateObtentionBac;
        }
   


        public int IdClient { get; set; }

        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }

        public DateTime? EnvoyéLe { get; set; } = DateTime.Now;
        public DateTime? DateObtentionBac { get; set; }
        //public Etat Etat { get; set; }
    }
}
