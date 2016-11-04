using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models
{
    public class AspNetUserInfoSup
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public Image Image { get; set; }
        public string Steam { get; set; }
        public string Blizzard { get; set; }
        public List<IdentityRole> Roles { get; set; }

    }

    public class Image
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }
        public int Taille { get; set; }
        public byte[] Data { get; set; }
    }
}
