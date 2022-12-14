using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Creneau> Creneaux { get; set; }
        public DbSet<Niveau> Niveaux { get; set; }
        public DbSet<NiveauxProf> NiveauxProfs { get; set; }
        public DbSet<DistanceDom> DistanceDoms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD
            optionsBuilder.UseMySql("server = localhost; user id = root; password = Hina ; database = PitAgora");
=======
            optionsBuilder.UseMySql("server = localhost; user id = root; password = Triqui24+ ; database = PitAgora");
>>>>>>> 75c1ae7 (mk/LayoutV1)

        }
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            // Création de la table Niveaux
            using (DalGen dal = new DalGen())
            {
                dal.CreerTableNiveaux();
            }

            // Création de parents, d'élèves, de profs et de créneaux avec les méthodes dédiées
            using (DalParent dal = new DalParent()) { 
                dal.CreerParent("Terrieur", "Marc", "mterrieur@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.CreerParent("Vaudage", "Annie", "avaudage@monmel.fr", "vvvvv", "11 rue Roli 75014 PARIS");
                dal.CreerParent("Potter", "Mary", "avaudage@monmel.fr", "vvvvv", "32 rue Delmer 59242 TEMPLEUVE");
                dal.CreerParent("Skywalker", "Leia", "avaudage@monmel.fr", "vvvvv", "33 bd Marius Vivier Merle 69003 LYON");
                dal.CreerParent("Blueberry", "Jean", "avaudage@monmel.fr", "vvvvv", "78 bd de Souville 84200 CARPENTRAS");
            }

            using (DalEleve dal = new DalEleve()) {
                dal.CreerEleve(1, "Terrieur", "Alain", "aterrieur1@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.CreerEleve(1, "Terrieur", "Alex", "aterrieur2@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.CreerEleve(2, "Vaudage", "Marie", "mvaudage@monmel.fr", "vvvvv", "11 rue Roli 75014 PARIS");
                dal.CreerEleve(3, "Potter", "Harry", "hpotter@monmel.fr", "ppppp", "32 rue Delmer 59242 TEMPLEUVE");
                dal.CreerEleve(4, "Skywalker", "Luke", "lskywalker@monmel.fr", "sssss", "33 bd Marius Vivier Merle 69003 LYON");
                dal.CreerEleve(5, "Blueberry", "Mike", "mbluberry@monmel.fr", "bbbbb", "78 bd de Souville 84200 CARPENTRAS");
            }

            using (DalProf dal = new DalProf())
            {
                dal.CreerProfesseur("Euler", "Leonhard", "leuler@monmel.fr", "eeeee", "2 rue Mozart 92160 ANTONY", "Maths", "Physique-Chimie");
                dal.CreerProfesseur("Einstein", "Albert", "aeinstein@monmel.fr", "eeeee", "11 rue Porte d’Orange 84200 CARPENTRAS", "Physique-Chimie");
                dal.CreerProfesseur("Darwin", "Charles", "cdarwin@monmel.fr", "ddddd", "645 route de la Châtaigneraie 69490 ANCY", "SVT");
                dal.CreerProfesseur("Descartes", "René", "rdescartes@monmel.fr", "ddddd", "32 rue Boileau 69006 LYON", "Maths", "SVT");
                dal.CreerProfesseur("Laplace", "Pierre-Simon", "pslaplace@monmel.fr", "lllll", "22 rue Roger Salengro 69009 LYON", "Maths");
            }

            using (DalCreneaux dal = new DalCreneaux())
            {
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 00, 00),1);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 30, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 11, 00, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 11, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 11, 00, 00), 3);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 00, 00), 3);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 30, 00), 3);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 30, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 17, 00, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 17, 30, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 00, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 30, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 00, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 30, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 00, 00), 5);
            }


            // Création d'instances à la main

            this.NiveauxProfs.AddRange(
                new NiveauxProf() { ProfesseurId = 1, NiveauId = 1 },
                new NiveauxProf() { ProfesseurId = 1, NiveauId = 2 },
                new NiveauxProf() { ProfesseurId = 1, NiveauId = 3 },
                new NiveauxProf() { ProfesseurId = 2, NiveauId = 3 },
                new NiveauxProf() { ProfesseurId = 3, NiveauId = 2 },
                new NiveauxProf() { ProfesseurId = 3, NiveauId = 3 },
                new NiveauxProf() { ProfesseurId = 4, NiveauId = 3 },
                new NiveauxProf() { ProfesseurId = 5, NiveauId = 3 }
                );

            List<Creneau> CreneauxResa1 = new List<Creneau>();
            CreneauxResa1.Add(this.Creneaux.Find(1));
            CreneauxResa1.Add(this.Creneaux.Find(2));
            CreneauxResa1.Add(this.Creneaux.Find(3));

            List<Creneau> CreneauxResa2 = new List<Creneau>();
            CreneauxResa2.Add(this.Creneaux.Find(4));
            CreneauxResa2.Add(this.Creneaux.Find(5));
            CreneauxResa2.Add(this.Creneaux.Find(6));

            //this.Reservations.AddRange(
            //   new Reservation
            //   {
            //       Id = 1,
            //       Eleve1Id = 1,
            //       ProfesseurId = 1,
            //       Matiere = "Maths",
            //       Niveau = "Terminale",
            //       Horaire = new DateTime(2023, 01, 05, 10, 00, 00),
            //       Creneaux = CreneauxResa,
            //       Prix = 90,
            //       Binome = false,
            //       Presentiel = false,
            //       EstValide = true
            //   }
            //   new Reservation
            //   {
            //       Id = 2,
            //       Eleve1Id = 1,
            //       Eleve2Id = 2,
            //       ProfesseurId = 3,
            //       Matiere = "SVT",
            //       Niveau = "Terminale",
            //       Horaire = new DateTime(2023, 01, 08, 17, 00, 00),
            //       Creneaux = CreneauxResa,
            //       Prix = 90,
            //       Binome = false,
            //       Presentiel = false,
            //       EstValide = true
            //   });


            /*
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



           );
           */

            this.SaveChanges();


        }

    }
}
