using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

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
        public DbSet<NiveauProf> NiveauxProfs { get; set; }
        public DbSet<DistanceDom> DistanceDoms { get; set; }
        public DbSet<AReserve> AReserve { get; set; }
        public DbSet<Matiere> Matieres { get; set; }

        public DbSet<MatiereProf> MatiereProfs { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }



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

            // Création des tables Niveaux et Matieres
            using (DalGen dal = new DalGen())
            {
                dal.CreerTableNiveaux();
                dal.CreerTableNMatieres();
            }


            // Création de parents, d'élèves, de profs et de créneaux avec les méthodes dédiées
            using (DalParent dal = new DalParent())
            {
                dal.CreerParent("Terrieur", "Marc", "mterrieur@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.CreerParent("Vaudage", "Annie", "avaudage@monmel.fr", "vvvvv", "11 rue Roli 75014 PARIS");
                dal.CreerParent("Potter", "Mary", "avaudage1@monmel.fr", "vvvvv", "32 rue Delmer 59242 TEMPLEUVE");
                dal.CreerParent("Skywalker", "Leia", "avaudage2@monmel.fr", "vvvvv", "33 bd Marius Vivier Merle 69003 LYON");
                dal.CreerParent("Blueberry", "Jean", "avaudage3@monmel.fr", "vvvvv", "78 bd de Souville 84200 CARPENTRAS");
            }

            using (DalEleve dal = new DalEleve())
            {
                dal.CreerEleve(1, "Terrieur", "Alain", "aterrieur1@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.CreerEleve(1, "Terrieur", "Alex", "aterrieur2@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.CreerEleve(2, "Vaudage", "Marie", "mvaudage@monmel.fr", "vvvvv", "11 rue Roli 75014 PARIS");
                dal.CreerEleve(3, "Potter", "Harry", "hpotter@monmel.fr", "ppppp", "32 rue Delmer 59242 TEMPLEUVE");
                dal.CreerEleve(4, "Skywalker", "Luke", "lskywalker@monmel.fr", "sssss", "33 bd Marius Vivier Merle 69003 LYON");
                dal.CreerEleve(5, "Blueberry", "Mike", "mbluberry@monmel.fr", "bbbbb", "78 bd de Souville 84200 CARPENTRAS");
            }

            using (DalProf dal = new DalProf())
            {
                dal.CreerProfesseur("Euler", "Leonhard", "leuler@monmel.fr", "eeeee", "2 rue Mozart 92160 ANTONY", 0);
                dal.CreerProfesseur("Einstein", "Albert", "aeinstein@monmel.fr", "eeeee", "11 rue Porte d’Orange 84200 CARPENTRAS", 0);
                dal.CreerProfesseur("Darwin", "Charles", "cdarwin@monmel.fr", "ddddd", "645 route de la Châtaigneraie 69490 ANCY", 3);
                dal.CreerProfesseur("Descartes", "René", "rdescartes@monmel.fr", "ddddd", "32 rue Boileau 69006 LYON", 3);
                dal.CreerProfesseur("Laplace", "Pierre-Simon", "pslaplace@monmel.fr", "lllll", "22 rue Roger Salengro 69009 LYON", 0);
            }

            using (DalCreneaux dal = new DalCreneaux())
            {
                dal.CreerCreneau(new DateTime(2022, 12, 14, 16, 00, 00), 1);    // cours de maths du 14/12
                dal.CreerCreneau(new DateTime(2022, 12, 14, 16, 30, 00), 1);
                dal.CreerCreneau(new DateTime(2022, 12, 14, 17, 00, 00), 1);
                dal.CreerCreneau(new DateTime(2022, 12, 17, 16, 00, 00), 2);    // cours de PC du 17/12
                dal.CreerCreneau(new DateTime(2022, 12, 17, 16, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 17, 17, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 21, 16, 00, 00), 1);    // cours de maths du 21/12
                dal.CreerCreneau(new DateTime(2022, 12, 21, 16, 30, 00), 1);
                dal.CreerCreneau(new DateTime(2022, 12, 21, 17, 00, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 16, 00, 00), 2);    // Cours de PC prévu le 04/01
                dal.CreerCreneau(new DateTime(2023, 01, 11, 16, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 17, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 09, 00, 00), 1);    // créneaux maths dispos le 11/01
                dal.CreerCreneau(new DateTime(2023, 01, 11, 09, 30, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 10, 00, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 10, 30, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 11, 00, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 10, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 10, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 11, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 11, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 00, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 30, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 16, 00, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 16, 30, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 17, 00, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 17, 30, 00), 5);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 00, 00), 3);    // créneaux sans maths
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 30, 00), 3);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 00, 00), 3);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 16, 00, 00), 4);
            }


            using (DalReservation dal = new DalReservation())
            {
                // Cours de maths du 14/12
                int id = dal.creerReservation(new Reservation() {
                    PrenomNomProf = "Leonhard Euler",
                    Horaire = new DateTime(2022, 12, 14, 16, 00, 00),
                    Jour = "Mercredi 14 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.maths,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, this.Creneaux.Find(1));
                dal.AffecterACreneau(id, this.Creneaux.Find(2));
                dal.AffecterACreneau(id, this.Creneaux.Find(3));
                this.AReserve.Add(new AReserve { EleveId = 1, ReservationId = id });

                // Cours de PC du 17/12  en binôme
                id = dal.creerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    Horaire = new DateTime(2022, 12, 17, 16, 00, 00),
                    Jour = "Samedi 17 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = true,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, this.Creneaux.Find(4));
                dal.AffecterACreneau(id, this.Creneaux.Find(5));
                dal.AffecterACreneau(id, this.Creneaux.Find(6));
                this.AReserve.AddRange(new AReserve { EleveId = 1, ReservationId = id }, new AReserve { EleveId = 2, ReservationId = id });

                // Cours de maths du 21/12
                id = dal.creerReservation(new Reservation()
                {
                    PrenomNomProf = "Leonhard Euler",
                    Horaire = new DateTime(2022, 12, 21, 16, 00, 00),
                    Jour = "Mercredi 21 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.maths,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, this.Creneaux.Find(7));
                dal.AffecterACreneau(id, this.Creneaux.Find(8));
                dal.AffecterACreneau(id, this.Creneaux.Find(9));
                this.AReserve.Add(new AReserve { EleveId = 1, ReservationId = id });

                // Cours de PC prévu le 05/01  en binôme
                id = dal.creerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    Horaire = new DateTime(2023, 01, 11, 16, 00, 00),
                    Jour = "Mercredi 4 janvier",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = true,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, this.Creneaux.Find(10));
                dal.AffecterACreneau(id, this.Creneaux.Find(11));
                dal.AffecterACreneau(id, this.Creneaux.Find(12));
                this.AReserve.AddRange(new AReserve { EleveId = 1, ReservationId = id }, new AReserve { EleveId = 2, ReservationId = id });

            }


            this.MatiereProfs.AddRange(
                new MatiereProf { MatiereId = 1, ProfesseurId = 1 },
                new MatiereProf { MatiereId = 2, ProfesseurId = 2 },
                new MatiereProf { MatiereId = 3, ProfesseurId = 3 },
                new MatiereProf { MatiereId = 1, ProfesseurId = 4 },
                new MatiereProf { MatiereId = 1, ProfesseurId = 2 },
                new MatiereProf { MatiereId = 2, ProfesseurId = 1 },
                new MatiereProf { MatiereId = 3, ProfesseurId = 5 }
                );

            this.NiveauxProfs.AddRange(
                new NiveauProf() { ProfesseurId = 1, NiveauId = 1 },
                new NiveauProf() { ProfesseurId = 1, NiveauId = 2 },
                new NiveauProf() { ProfesseurId = 1, NiveauId = 3 },
                new NiveauProf() { ProfesseurId = 2, NiveauId = 3 },
                new NiveauProf() { ProfesseurId = 3, NiveauId = 2 },
                new NiveauProf() { ProfesseurId = 3, NiveauId = 3 },
                new NiveauProf() { ProfesseurId = 4, NiveauId = 3 },
                new NiveauProf() { ProfesseurId = 5, NiveauId = 3 }
                );


            this.Evaluations.AddRange(
                new Evaluation { Contenu = "Nous avons abordé les sujets suivants blablabla. Untel a eu des difficultés sur l'exercice 3." },
                new Evaluation { Contenu = "Eleve à l'aise sur tel sujets, necessite d'approfondir tel aspect." }
                );



            this.SaveChanges();


        }

    }
}
