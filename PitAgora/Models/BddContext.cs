using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System;

namespace PitAgora.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = localhost; user id = root; password = rrrrr ; database = PitAgora");
        }
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();


            this.Eleves.AddRange(
                new Eleve { Id = 1, UtilisateurId = 1, CreditCours = 400, CreditPythos = 200 },
                new Eleve { Id = 2, UtilisateurId = 2, CreditCours = 50, CreditPythos = 20 }
            );

            this.Professeurs.AddRange(
                new Professeur { Id = 1, UtilisateurId = 3, CreditProf = 300, Matiere1 = "Maths", Matiere2 = "Physique" },
                new Professeur { Id = 2, UtilisateurId = 4, CreditProf = 1000, Matiere1 = "Biologie" }
            );


            this.Utilisateurs.AddRange(
                new Utilisateur { Id = 1, Adresse = "125 rue de normandie", MotDePasse = "Hina", Mail = "Toto@toto.com", PersonneId = 1 },
                 new Utilisateur { Id = 2, Adresse = "12 avenue Denis Papin", MotDePasse = "Bouche", Mail = "Heimdal@toto.com", PersonneId = 2 },
                  new Utilisateur { Id = 3, Adresse = "1 place Arago", MotDePasse = "Tartelette", Mail = "Giroud@goat.com", PersonneId = 3 },
                  new Utilisateur { Id = 4, Adresse = "2 rue Mozart", MotDePasse = "Cornichon", Mail = "matheux@gmail.com", PersonneId = 4 }
            );

            this.Personnes.AddRange(
            new Personne { Id = 1, Nom = "Brogniard", Prenom = "Eddy" },
          new Personne { Id = 2, Nom = "Potter", Prenom = "Harry" },
          new Personne { Id = 3, Nom = "Duchmolle", Prenom = "Machin" },
          new Personne { Id = 4, Nom = "Distraite", Prenom = "Laura" }

            );

            this.SaveChanges();


        }

    }
}
