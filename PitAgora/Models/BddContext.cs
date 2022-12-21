using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
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
        public DbSet<MatiereProf> MatieresProfs { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			if (System.Diagnostics.Debugger.IsAttached)
            {
               optionsBuilder.UseMySql("server = localhost; user id = root; password = rrrrr ; database = PitAgora");  // connexion string. Attention au password. avec comme nom de BDD : ChoixSejourTest
            }
            else
            {
                IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            }
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
                dal.CreerParent("Potter", "Mary", "avaudage@monmel.fr", "vvvvv", "32 rue Delmer 59242 TEMPLEUVE");
                dal.CreerParent("Skywalker", "Leia", "avaudage@monmel.fr", "vvvvv", "33 bd Marius Vivier Merle 69003 LYON");
                dal.CreerParent("Blueberry", "Jean", "avaudage@monmel.fr", "vvvvv", "78 bd de Souville 84200 CARPENTRAS");
            }

            using (DalEleve dal = new DalEleve())
            {
                dal.CreerEleve(1, "Terrieur", "Alain", "aterrieur1@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.ModifierPythos(1, 30);
                dal.ModifierCreditCours(1, 100);
                dal.CreerEleve(1, "Terrieur", "Alex", "aterrieur2@monmel.fr", "ttttt", "64 rue Velpeau 92160 ANTONY");
                dal.ModifierPythos(2, 30);
                dal.ModifierCreditCours(2, 150);
                dal.CreerEleve(2, "Vaudage", "Marie", "mvaudage@monmel.fr", "vvvvv", "11 rue Roli 75014 PARIS");
                dal.ModifierPythos(3, 20);
                dal.ModifierCreditCours(3, 75);
                dal.CreerEleve(3, "Potter", "Harry", "hpotter@monmel.fr", "ppppp", "32 rue Delmer 59242 TEMPLEUVE");
                dal.ModifierPythos(4, 60);
                dal.ModifierCreditCours(4, 200);
                dal.CreerEleve(4, "Skywalker", "Luke", "lskywalker@monmel.fr", "sssss", "33 bd Marius Vivier Merle 69003 LYON");
                dal.ModifierPythos(5, 50);
                dal.ModifierCreditCours(5, 300);
                dal.CreerEleve(5, "Blueberry", "Mike", "mbluberry@monmel.fr", "bbbbb", "78 bd de Souville 84200 CARPENTRAS");
                dal.ModifierPythos(6, 00);
                dal.ModifierCreditCours(6, 250);
            }



            using (DalProf dal = new DalProf())
            {
                dal.CreerProfesseur("Euler", "Leonhard", "leuler@monmel.fr", "eeeee", "2 rue Mozart 92160 ANTONY");
                dal.ModifierCreditProf(1, 90);
                dal.CreerProfesseur("Einstein", "Albert", "aeinstein@monmel.fr", "eeeee", "11 rue Porte d’Orange 84200 CARPENTRAS");
                dal.ModifierCreditProf(2, 67.5);
                dal.CreerProfesseur("Darwin", "Charles", "cdarwin@monmel.fr", "ddddd", "645 route de la Châtaigneraie 69490 ANCY");
                dal.ModifierCreditProf(3, 90);
                dal.CreerProfesseur("Descartes", "René", "rdescartes@monmel.fr", "ddddd", "32 rue Boileau 69006 LYON");
                dal.ModifierCreditProf(4, 90);
                dal.CreerProfesseur("Laplace", "Pierre-Simon", "pslaplace@monmel.fr", "lllll", "22 rue Roger Salengro 69009 LYON");
                dal.ModifierCreditProf(5, 0);
                dal.CreerProfesseur("Curie", "Marie", "mcurie@monmel.fr", "ccccc", "61 avenue Albert Sarraut 75011 Paris");
                dal.ModifierCreditProf(6, 110);
                dal.CreerProfesseur("Baer", "Ralph", "rbaer@monmel.fr", "bbbbb", " 6 Rue Neuve des Capucins 44000 Nantes");
                dal.ModifierCreditProf(7, 67.5);
            }

            using (DalCreneaux dal = new DalCreneaux())
            {
                dal.CreerCreneau(new DateTime(2022, 12, 14, 16, 00, 00), 1);    // 1-3 : cours de maths du 14/12
                dal.CreerCreneau(new DateTime(2022, 12, 14, 16, 30, 00), 1);
                dal.CreerCreneau(new DateTime(2022, 12, 14, 17, 00, 00), 1);
                dal.CreerCreneau(new DateTime(2022, 12, 20, 16, 00, 00), 2);    // 4-6 :cours de PC du 20/12
                dal.CreerCreneau(new DateTime(2022, 12, 20, 16, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 20, 17, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 21, 16, 00, 00), 1);    // 7-9 : cours de maths du 21/12
                dal.CreerCreneau(new DateTime(2022, 12, 21, 16, 30, 00), 1);
                dal.CreerCreneau(new DateTime(2022, 12, 21, 17, 00, 00), 1);
                dal.CreerCreneau(new DateTime(2023, 01, 04, 16, 00, 00), 2);    // 10-12 : Cours de PC prévu le 04/01
                dal.CreerCreneau(new DateTime(2023, 01, 04, 16, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2023, 01, 04, 17, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 09, 00, 00), 1);    // 13-31 :créneaux maths dispos le 11/01
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
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 00, 00), 3);    // 32-39 : créneaux sans maths le 11/01
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 30, 00), 3);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 00, 00), 3);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 14, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 15, 30, 00), 4);
                dal.CreerCreneau(new DateTime(2023, 01, 11, 16, 00, 00), 4);
                dal.CreerCreneau(new DateTime(2022, 12, 22, 10, 00, 00), 2);    // 40-41 : cours de PC prévu le 22/12 avec Harry
                dal.CreerCreneau(new DateTime(2022, 12, 22, 10, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 22, 14, 00, 00), 2);    // 42-43 : cours de PC prévu le 22/12 avec Luke
                dal.CreerCreneau(new DateTime(2022, 12, 22, 14, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 22, 16, 00, 00), 2);    // 44-46 : cours de PC prévu le 22/12 avec Marie
                dal.CreerCreneau(new DateTime(2022, 12, 22, 16, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 22, 17, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 17, 16, 00, 00), 2);    // 47-49 : cours de PC du 17/12 avec Marie
                dal.CreerCreneau(new DateTime(2022, 12, 17, 16, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 17, 17, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 17, 10, 00, 00), 2);    // 50-52 : cours de PC du 17/12 avec Harry
                dal.CreerCreneau(new DateTime(2022, 12, 17, 10, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 17, 11, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 16, 11, 00, 00), 2);    //dispos einstein non reservés
                dal.CreerCreneau(new DateTime(2022, 12, 16, 11, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 16, 12, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 22, 12, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 22, 12, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 20, 10, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 20, 10, 30, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 24, 11, 00, 00), 2);
                dal.CreerCreneau(new DateTime(2022, 12, 24, 11, 30, 00), 2);


            }


            this.Evaluations.AddRange(
                new Evaluation        // cours de maths du 14/12 Alain / Euler
                {
                    Id = 1,
                    Contenu = "Sujet abordé : dérivation des fonctions usuelles. Cours et méthodes bien compris, il faut encore t'entraîner pour aquérir les automatismes."
                },
                new Evaluation          // 47-49 : cours de PC du 17/12 Marie / Einstein
                {
                    Id = 2,
                    Contenu = "Sujet abordé : réactions acide/base. Bien compris."
                },
                new Evaluation        // cours de PC du 14/12 Harry / Einstein
                {
                    Id = 3,
                    Contenu = "Sujet abordé : Circuit électriques. Il faut retravailler la loi des noeuds."
                }
            );
            this.SaveChanges();



            using (DalReservation dal = new DalReservation())
            {
                // Cours de maths du 14/12
                int id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Leonhard Euler",
                    PrenomEleve = "Alain",
                    Horaire = new DateTime(2022, 12, 14, 16, 00, 00),
                    Jour = "Mercredi 14 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.maths,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true,
                    EvaluationId = 1,
                    Evaluation = dal.GetEvaluation(1)
                });
                dal.AffecterACreneau(id, 1);
                dal.AffecterACreneau(id, 2);
                dal.AffecterACreneau(id, 3);
                this.AReserve.Add(new AReserve { EleveId = 1, ReservationId = id });

                // Cours de PC du 20/12 en binôme Alain & Alex
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    PrenomEleve = "Alain & Alex",
                    Horaire = new DateTime(2022, 12, 20, 16, 00, 00),
                    Jour = "Mardi 20 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = true,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, 4);
                dal.AffecterACreneau(id, 5);
                dal.AffecterACreneau(id, 6);
                this.AReserve.AddRange(new AReserve { EleveId = 1, ReservationId = id }, new AReserve { EleveId = 2, ReservationId = id });

                // Cours de maths du 21/12 avec Alain
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Leonhard Euler",
                    PrenomEleve = "Alain",
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
                dal.AffecterACreneau(id, 7);
                dal.AffecterACreneau(id, 8);
                dal.AffecterACreneau(id, 9);
                this.AReserve.Add(new AReserve { EleveId = 1, ReservationId = id });

                // Cours de PC prévu le 04/01 en binôme Alain & Alex
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    PrenomEleve = "Alain & Alex",
                    Horaire = new DateTime(2023, 01, 04, 16, 00, 00),
                    Jour = "Mercredi 4 janvier",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = true,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, 10);
                dal.AffecterACreneau(id, 11);
                dal.AffecterACreneau(id, 12);
                this.AReserve.AddRange(new AReserve { EleveId = 1, ReservationId = id }, new AReserve { EleveId = 2, ReservationId = id });

                // Cours de PC prévu le 22/12 avec Harry
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    PrenomEleve = "Harry",
                    Horaire = new DateTime(2022, 12, 22, 10, 00, 00),
                    Jour = "Jeudi 22 décembre",
                    DureeMinutes = 60,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 45,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, 40);
                dal.AffecterACreneau(id, 41);
                this.AReserve.AddRange(new AReserve { EleveId = 4, ReservationId = id });

                // Cours de PC prévu le 22/12 avec Luke
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    PrenomEleve = "Luke",
                    Horaire = new DateTime(2022, 12, 22, 14, 00, 00),
                    Jour = "Jeudi 22 décembre",
                    DureeMinutes = 60,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 45,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, 42);
                dal.AffecterACreneau(id, 43);
                this.AReserve.AddRange(new AReserve { EleveId = 5, ReservationId = id });

                // Cours de PC prévu le 22/12 avec Marie
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    PrenomEleve = "Marie",
                    Horaire = new DateTime(2022, 12, 22, 16, 00, 00),
                    Jour = "Jeudi 22 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true
                });
                dal.AffecterACreneau(id, 44);
                dal.AffecterACreneau(id, 45);
                dal.AffecterACreneau(id, 46);
                this.AReserve.AddRange(new AReserve { EleveId = 5, ReservationId = id });

                // Cours de PC du 17/12 avec Marie
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    PrenomEleve = "Marie",
                    Horaire = new DateTime(2022, 12, 17, 16, 00, 00),
                    Jour = "Samedi 17 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true,
                    EvaluationId = 2,
                    Evaluation = dal.GetEvaluation(2)
                });
                dal.AffecterACreneau(id, 47);
                dal.AffecterACreneau(id, 48);
                dal.AffecterACreneau(id, 49);
                this.AReserve.AddRange(new AReserve { EleveId = 3, ReservationId = id });

                // Cours de PC du 17/12 avec Harry
                id = dal.CreerReservation(new Reservation()
                {
                    PrenomNomProf = "Albert Einstein",
                    PrenomEleve = "Harry",
                    Horaire = new DateTime(2022, 12, 17, 10, 00, 00),
                    Jour = "Samedi 17 décembre",
                    DureeMinutes = 90,
                    Matiere = MatiereEnum.physique,
                    Niveau = NiveauEnum.premiereGenerale,
                    Prix = 67.5,
                    EstEnBinome = false,
                    EstEnPresentiel = false,
                    EstValide = true,
                    EvaluationId = 3,
                    Evaluation = dal.GetEvaluation(3)
                });
                dal.AffecterACreneau(id, 50);
                dal.AffecterACreneau(id, 51);
                dal.AffecterACreneau(id, 52);
                this.AReserve.AddRange(new AReserve { EleveId = 4, ReservationId = id });

            }

            //Affectation d'évaluations, attention aux dates


            // Matières enseignées par chaque professeur
            this.MatieresProfs.AddRange(
                new MatiereProf { MatiereId = 1, ProfesseurId = 1 },
                new MatiereProf { MatiereId = 2, ProfesseurId = 2 },
                new MatiereProf { MatiereId = 3, ProfesseurId = 3 },
                new MatiereProf { MatiereId = 1, ProfesseurId = 4 },
                new MatiereProf { MatiereId = 1, ProfesseurId = 2 },
                new MatiereProf { MatiereId = 2, ProfesseurId = 1 },
                new MatiereProf { MatiereId = 3, ProfesseurId = 5 }
                );

            // Niveaux enseignées par chaque professeur
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


            this.SaveChanges();

        }

    }
}
