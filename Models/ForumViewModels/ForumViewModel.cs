using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.ForumViewModels
{
    public class ForumViewModel
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public DateTime DateCréation { get; set; }
        public string Dernier { get; set; }
        public DateTime DateModifier { get; set; }
        public string NombreMessages { get; set; }
    }

    public static class Posts
    {
        
    }
}
