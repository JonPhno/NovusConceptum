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

        public static void AjouterUsagers()
        {
            ApplicationUser[] user =
            {
                new ApplicationUser() {
                    UserName = "Admin",
                    PasswordHash = "Admin123!",
                    Email = "admin@novusconceptum.com",
                    InfoSup = new AspNetUserInfoSup()
                    {
                        Roles = new List<IdentityRole>(),
                        Image = new Image()
                    }
                },
                new ApplicationUser()
                {
                    UserName = "Mod",
                    PasswordHash = "Mod123!",
                    Email = "mod@novusconceptum.com",
                    InfoSup = new AspNetUserInfoSup()
                    {
                        Roles = new List<IdentityRole>(),
                        Image = new Image()
                    }

                },
                new ApplicationUser() //Cet utilisateur est banni du forum
                {
                    UserName = "Willp3",
                    PasswordHash = "Will123!",
                    Email = "willp3@novusconceptum.com",
                    InfoSup = new AspNetUserInfoSup()
                    {
                        Roles = new List<IdentityRole>(),
                        Image = new Image()
                    }

                },
                new ApplicationUser() //Cet utilisateur aura 2 roles.
                {
                    UserName = "Angela",
                    PasswordHash = "Mercy123!",
                    Email = "AngelaZiegler@novusconceptum.com",
                    InfoSup = new AspNetUserInfoSup()
                    {
                        Roles = new List<IdentityRole>(),
                        Image = new Image()
                    }

                }
            };

            foreach (ApplicationUser u in user)
            {
                u.ConcurrencyStamp = Guid.NewGuid().ToString();
                u.LockoutEnabled = true;
                u.NormalizedEmail = u.Email.ToUpper();
                u.NormalizedUserName = u.UserName.ToUpper();
                u.SecurityStamp = Guid.NewGuid().ToString();
                u.PasswordHash = _pass.HashPassword(u, u.PasswordHash);
            }

            foreach (ApplicationUser u in user)
            {
                if (!Context.Users.Any(t => t.NormalizedUserName == u.NormalizedUserName))
                {
                    Context.Users.Add(u);
                }
            }

            Context.SaveChanges();
        }

        public static void AjouterRoles()
        {
            IdentityRole[] roles =
            {
                new IdentityRole() //Accès complet
                {
                    Name = "Administrateur"
                },
                new IdentityRole() //Accès minimum
                {
                    Name = "Utilisateur"
                },
                new IdentityRole() //Peut effacer les sujets et les post. Ne peut pas modifier les droits des utilisateurs
                {
                    Name = "Modérateur"
                },
                new IdentityRole()
                {
                    Name = "ExclusionForum"
                },
                new IdentityRole() //Peut effacer les posts mais pas les sujets.
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
                    UserId = Context.Users.Single(u => u.Email == "AngelaZiegler@novusconceptum.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Utilisateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "AngelaZiegler@novusconceptum.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Ange").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "admin@novusconceptum.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Administrateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "mod@novusconceptum.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Modérateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "willp3@novusconceptum.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Utilisateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "willp3@novusconceptum.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "ExclusionForum").Id
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
