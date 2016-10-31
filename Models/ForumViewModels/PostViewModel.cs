using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.ForumViewModels
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public string Auteur { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int SujetID { get; set; }
        public Sujet Suj { get; set; }

        public PostViewModel()
        {

        }

        public PostViewModel(Post post)
        {
            ID = post.ID;
            Auteur = post.Auteur;
            Date = post.Date;
            Message = post.Message;
            SujetID = post.SujetID;
            Suj = post.Suj;
        }
    }
}
