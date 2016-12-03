using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NovusConceptum.Data;

namespace NovusConceptum.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161203024807_ModifServeur")]
    partial class ModifServeur
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int?>("AspNetUserInfoSupID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("AspNetUserInfoSupID");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NovusConceptum.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("SondageID");

                    b.Property<int?>("TournoisID");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("SondageID");

                    b.HasIndex("TournoisID");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NovusConceptum.Models.AspNetUserInfoSup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Blizzard");

                    b.Property<int?>("ImageID");

                    b.Property<string>("Steam");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ImageID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("AspNetUserInfoSup");
                });

            modelBuilder.Entity("NovusConceptum.Models.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data");

                    b.Property<string>("Nom");

                    b.Property<int>("Taille");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("NovusConceptum.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuteurId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Message");

                    b.Property<int>("SujetID");

                    b.HasKey("ID");

                    b.HasIndex("AuteurId");

                    b.HasIndex("SujetID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("NovusConceptum.Models.Serveur", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdresseIp");

                    b.Property<string>("Description");

                    b.Property<int>("Joueurs");

                    b.Property<int>("JoueursMax");

                    b.Property<string>("Nom");

                    b.Property<bool>("Ouvert");

                    b.Property<int>("Port");

                    b.Property<string>("Version");

                    b.HasKey("ID");

                    b.ToTable("Serveurs");
                });

            modelBuilder.Entity("NovusConceptum.Models.Sondage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Choix");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateFin");

                    b.Property<string>("Description");

                    b.Property<string>("Nom");

                    b.Property<string>("Options");

                    b.HasKey("ID");

                    b.ToTable("Sondages");
                });

            modelBuilder.Entity("NovusConceptum.Models.Sujet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuteurId");

                    b.Property<DateTime>("DateCreation");

                    b.Property<DateTime>("DateModifier");

                    b.Property<string>("DernierId");

                    b.Property<string>("Description");

                    b.Property<int>("NombreMessages");

                    b.Property<string>("PremierMessage")
                        .IsRequired();

                    b.Property<bool>("Test2");

                    b.Property<string>("Titre");

                    b.HasKey("ID");

                    b.HasIndex("AuteurId");

                    b.HasIndex("DernierId");

                    b.ToTable("Sujets");
                });

            modelBuilder.Entity("NovusConceptum.Models.Tournois", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("FinInscriptions");

                    b.Property<string>("Jeu");

                    b.Property<string>("Nom");

                    b.Property<int>("NombreEquipe");

                    b.Property<int>("NombreJoueursEquipe");

                    b.Property<string>("Serveur");

                    b.Property<bool>("Spectateurs");

                    b.HasKey("ID");

                    b.ToTable("Tournois");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.HasOne("NovusConceptum.Models.AspNetUserInfoSup")
                        .WithMany("Roles")
                        .HasForeignKey("AspNetUserInfoSupID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NovusConceptum.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NovusConceptum.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NovusConceptum.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NovusConceptum.Models.ApplicationUser", b =>
                {
                    b.HasOne("NovusConceptum.Models.Sondage")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("SondageID");

                    b.HasOne("NovusConceptum.Models.Tournois")
                        .WithMany("Joueurs")
                        .HasForeignKey("TournoisID");
                });

            modelBuilder.Entity("NovusConceptum.Models.AspNetUserInfoSup", b =>
                {
                    b.HasOne("NovusConceptum.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageID");

                    b.HasOne("NovusConceptum.Models.ApplicationUser", "User")
                        .WithOne("InfoSup")
                        .HasForeignKey("NovusConceptum.Models.AspNetUserInfoSup", "UserID");
                });

            modelBuilder.Entity("NovusConceptum.Models.Post", b =>
                {
                    b.HasOne("NovusConceptum.Models.ApplicationUser", "Auteur")
                        .WithMany()
                        .HasForeignKey("AuteurId");

                    b.HasOne("NovusConceptum.Models.Sujet", "Suj")
                        .WithMany("Posts")
                        .HasForeignKey("SujetID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NovusConceptum.Models.Sujet", b =>
                {
                    b.HasOne("NovusConceptum.Models.ApplicationUser", "Auteur")
                        .WithMany()
                        .HasForeignKey("AuteurId");

                    b.HasOne("NovusConceptum.Models.ApplicationUser", "Dernier")
                        .WithMany()
                        .HasForeignKey("DernierId");
                });
        }
    }
}
