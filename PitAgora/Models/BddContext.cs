using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using static PitAgora.Models.Matiere;
using static PitAgora.Models.Niveau;

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
        public DbSet<AReserve> AReserves { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = localhost; user id = root; password = Hina ; database = PitAgora");
        }

        //Methode suivante relatives à authentification et autorisation//////////////////////////////////////////////////
        public Utilisateur Authentifier(string mail, string motDePasse)
        {
            string password = EncodeMD5(motDePasse);
            Utilisateur user = Utilisateurs.FirstOrDefault(u => u.Mail == mail && u.MotDePasse == password);
            return user;
        }
        public string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";

            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        //Methode suivante relatives à authentification et autorisation//////////////////////////////////////////////////

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
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 11, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 11, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 11, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 10, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 17, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 17, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 14, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 00, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 15, 30, 00));
                dal.CreerCreneau(new DateTime(2023, 01, 05, 16, 00, 00));
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

            this.Reservations.AddRange(
               new Reservation
               {
                   Id = 1,
                   Horaire = new DateTime(2023, 01, 05, 10, 00, 00),
                   Prix = 90,
                   EstEnBinome = false,
                   EstEnPresentiel = false,
                   EstValide = true
               },
               new Reservation
               {
                   Id = 2,
                   Horaire = new DateTime(2023, 01, 08, 17, 00, 00),
                   Prix = 90,
                   EstEnBinome = true,
                   EstEnPresentiel = false,
                   EstValide = true
               }); ;

            this.AReserves.AddRange(
                new AReserve { EleveId = 1, ReservationId = 1 },
            new AReserve { EleveId = 2, ReservationId = 2 },
            new AReserve { EleveId = 3, ReservationId = 2 }
            );

            this.SaveChanges();


        }

    }
}
