﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.ForumViewModels
{
    public class Discussions
    {
        [Key]
        public int ID { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public DateTime DateCréation { get; set; }
        public string Dernier { get; set; }
        public DateTime DateModifier { get; set; }
        public string NombreMessages { get; set; }
        public List<Post> Posts { get; set; }
        


    }

    public class Post
    {

        public string Auteur { get; set; }
        //public image MyProperty { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }

}
