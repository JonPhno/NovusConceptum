using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.ForumViewModels
{
    public class ForumViewModel
    {
        public int ID { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public DateTime DateCréation { get; set; }
        public string Dernier { get; set; }
        public DateTime DateModifier { get; set; }
        public int NombreMessages { get; set; }
        public List<Post> Posts { get; set; }

        public ForumViewModel()
        {

        }

        public ForumViewModel(Sujet sujet)
        {
            ID = sujet.ID;
            Titre = sujet.Titre;
            Description = sujet.Description;
            Auteur = sujet.Auteur;
            DateCréation = sujet.DateCreation;
            Dernier = sujet.Dernier;
            DateModifier = sujet.DateModifier;
            NombreMessages = sujet.NombreMessages;
            if (sujet.Posts != null)
            {
                Posts = sujet.Posts;
            }
        }
    }

    
}
