using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.TournoisViewModels
{
    public class TournoisViewModel
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
        public ICollection<AspNetUsersTournois> Joueurs { get; set; }
        public int PlacesRestantes { get; set; }

        public TournoisViewModel()
        {

        }

        public TournoisViewModel(Tournois t)
        {
            ID = t.ID;
            Nom = t.Nom;
            Jeu = t.Jeu;
            Serveur = t.Serveur;
            Spectateurs = t.Spectateurs;
            FinInscriptions = t.FinInscriptions;
            Date = t.Date;
            NombreEquipe = t.NombreEquipe;
            NombreJoueursEquipe = t.NombreJoueursEquipe;
            if (t.Joueurs != null)
            {
                Joueurs = t.Joueurs;
                PlacesRestantes = NombreEquipe * NombreJoueursEquipe - Joueurs.Count;

            }
            else
            {
                PlacesRestantes = NombreEquipe * NombreJoueursEquipe;
            }
        }
    }
}
