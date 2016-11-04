using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.MembresViewModels
{
    public class MembresViewModel
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public List<IdentityRole> Roles { get; set; }

        public MembresViewModel()
        {

        }

        public MembresViewModel(ApplicationUser u)
        {
            User = u;
            Roles = new List<IdentityRole>();
        }
    }
}
