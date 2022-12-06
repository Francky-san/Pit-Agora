using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System;

namespace PitAgora.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Parent> Parents { get; set; }
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

            // Création de parents, d'élèves et de profs avec les méthodes dédiées

            using (DalParents dal = new DalParents()) { 
                dal.CreerParent("Terrieur", "Marc", "mterrieur@monmel.fr", "ttttt", "3 pl de la Mairie 86210 Saint Médart");
                dal.CreerParent("Vaudage", "Annie", "avaudage@monmel.fr", "vvvvv", "2 rue Mozart 89420 Louhans");
            }

            using (DalParents dal = new DalParents()) {   // à changer en DalEleve
                dal.CreerEleve(1, "Terrieur", "Alain", "aterrieur1@monmel.fr", "ttttt", "3 pl de la Mairie 86210 Saint Médart");
                dal.CreerEleve(1, "Terrieur", "Alex", "aterrieur2@monmel.fr", "ttttt", "3 pl de la Mairie 86210 Saint Médart");
                dal.CreerEleve(2, "Vaudage", "Marie", "mvaudage@monmel.fr", "vvvvv", "2 rue Mozart 89420 Louhans");
            }

            using (DalParents dal = new DalParents()) {   // à changer en DalProf
                dal.CreerProfesseur("Euler", "Leonhard", "leuler@monmel.fr", "eeeee", "12 rue de l'algèbre 75006 Paris", "Maths");
                dal.CreerProfesseur("Einstein", "Albert", "aeinstein@monmel.fr", "eeeee", "20 rue de la lumière 75009 Paris", "Physique-Chimie");
                dal.CreerProfesseur("Darwin", "Charles", "cdarwin@monmel.fr", "ddddd", "8 rue ds Galapagos 75014 Paris", "SVT");
            }

            /*
            // Création d'élèves et de profs à la main
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
            */

            this.SaveChanges();


        }

    }
}
