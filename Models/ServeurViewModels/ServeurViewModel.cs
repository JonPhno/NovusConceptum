﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models
{
    public class ServeurViewModel
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public bool Ouvert { get; set; }
        public string Version { get; set; }
        public int JoueursMax { get; set; }
        public int Joueurs { get; set; }
        public string Description { get; set; }
        public string AdresseIp { get; set; }
        public int Port { get; set; }

        public ServeurViewModel()
        {

        }

        public ServeurViewModel(Serveur s)
        {
            ID = s.ID;
            Nom = s.Nom;
            Ouvert = s.Ouvert;
            Version = s.Version;
            JoueursMax = s.JoueursMax;
            Joueurs = s.Joueurs;
            Description = s.Description;
            AdresseIp = s.AdresseIp;
            Port = s.Port;
        }
    }
}
