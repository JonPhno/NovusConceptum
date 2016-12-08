using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models
{
    public class AspNetUsersTournois
    {
        public int Id { get; set; }

        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        public int TournoisId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Tournois Tournois { get; set; }
    }
}
