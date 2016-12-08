using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovusConceptum.Models;
using NovusConceptum.Models.ForumViewModels;

namespace NovusConceptum.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Sujet> Sujets { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AspNetUserInfoSup> AspNetUserInfoSup { get; set; }
        public DbSet<Tournois> Tournois { get; set; }
        public DbSet<Sondage> Sondages { get; set; }
        public DbSet<AspNetUsersTournois> AspNetUsersTournois { get; set; }
        public DbSet<AspNetUsersSondages> AspNetUsersSondages { get; set; }
        public DbSet<Serveur> Serveurs { get; set; }
        public Image Image { get; set; }






        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
