using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models
{
    public class Tournois
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Jeu { get; set; }
        public string Serveur { get; set; }
        public bool Spectateurs { get; set; }
        public DateTime FinInscriptions { get; set; }
        public DateTime Date { get; set; }
        public int NombreEquipe { get; set; }
        public int NombreJoueursEquipe { get; set; }
        public List<ApplicationUser> Joueurs { get; set; }
    }
}
