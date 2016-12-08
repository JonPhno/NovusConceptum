using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models
{
    public class Sondage
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Options { get; set; }
        public string Choix { get; set; }
        public virtual ICollection<AspNetUsersSondages> Utilisateurs { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateFin { get; set; }
    }
}
