using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NovusConceptum.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public AspNetUserInfoSup InfoSup { get; set; }
        public virtual ICollection<Sondage> Sondages { get; set; }
        public virtual ICollection<Tournois> Tournois { get; set; }

    }
}
