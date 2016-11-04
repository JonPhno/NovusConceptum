using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NovusConceptum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Data
{
    public class SeedData
    {
        #region Prop
        static public ApplicationDbContext Context { get; set; }
        #endregion

        #region Champs
        static PasswordHasher<ApplicationUser> _pass = new PasswordHasher<ApplicationUser>();
        #endregion
        public static void AjouterRoles()
        {
            IdentityRole[] roles =
            {
                new IdentityRole()
                {
                    Name = "Administrateur"
                },
                new IdentityRole()
                {
                    Name = "Utilisateur"
                },
                new IdentityRole()
                {
                    Name = "Modérateur"
                },
                new IdentityRole()
                {
                    Name = "ExclusionForum"
                },
                new IdentityRole()
                {
                    Name = "Ange"
                }
            };

            foreach (IdentityRole role in roles)
            {
                role.NormalizedName = role.Name.ToUpper();
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            //Save roles
            foreach (IdentityRole role in roles)
            {
                if (!Context.Roles.Any(r => r.NormalizedName == role.NormalizedName))
                {
                    Context.Roles.Add(role);
                }
            }

            Context.SaveChanges();
        }
        public static void AssocierRolesUsagers()
        {
            IdentityUserRole<string>[] users_roles =
            {
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.SingleOrDefault(u => u.Email == "angel@overwatch.com").Id,
                    RoleId = Context.Roles.SingleOrDefault(r => r.Name == "Administrateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.SingleOrDefault(u => u.Email == "angel@overwatch.com").Id,
                    RoleId = Context.Roles.SingleOrDefault(r => r.Name == "Ange").Id
                }
            };

            //Save
            if (!Context.UserRoles.Any())
            {
                Context.UserRoles.AddRange(users_roles);
                Context.SaveChanges();
            }
        }
    }
}
