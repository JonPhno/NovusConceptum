using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.SondageViewModel
{
    public class SondageViewModel
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public List<string> Options { get; set; }
        public List<int> Choix { get; set; }
        public List<ApplicationUser> Utilisateurs { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateFin { get; set; }

        public SondageViewModel()
        {

        }

        public SondageViewModel(Sondage s)
        {
            ID = s.ID;
            Nom = s.Nom;
            Description = s.Description;
            if (s.Options != null)
            {
                
                string[] split = s.Options.Split(',');
                Options = new List<string>();
                for (int i = 0; i < split.Length; i++)
                {
                    Options.Add(split[i]);
                }
            }
            if (s.Choix != null)
            {
                string[] split = s.Choix.Split(',');
                Choix = new List<int>();
                for (int i = 0; i < split.Length; i++)
                {
                    Choix.Add(int.Parse(split[i]));
                }
            }
            if (s.Utilisateurs != null)
            {
                Utilisateurs = s.Utilisateurs;
            }
            Date = s.Date;
            DateFin = s.DateFin;
        }
    }
}
