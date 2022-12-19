using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;


namespace PitAgora.Models
{
    public class DalProf : IDisposable
    {
        private BddContext _bddContext;
        //Constructeur 
        public DalProf()
        {
            _bddContext = new BddContext();
        }
        public void Dispose()
        {
            _bddContext.Dispose();
        }

        //Méthode récupérer liste complète des professeurs avec jointures utilisateur et personne pour accèder à tous les attributs
        public List<Professeur> ObtientTousLesProfesseurs()
        {
            return _bddContext.Professeurs.Include(p => p.Utilisateur).ThenInclude(u => u.Personne).ToList();
        }


        public Professeur ObtenirUnProf(int id)
        {
            Professeur unProf = _bddContext.Professeurs.Include(p => p.Utilisateur).ThenInclude(u => u.Personne).Where(p => p.Id == id).FirstOrDefault();
            return unProf;
        }

        //Méthode création d'un profeseur
        public int CreerProfesseur(string nom, string prenom, string mail, string motDePasse, string adresse)
        {
            string mdp = _bddContext.EncodeMD5(motDePasse);
            Personne personne = new Personne { Nom = nom, Prenom = prenom };
            _bddContext.Personnes.Add(personne);
            _bddContext.SaveChanges();
            Utilisateur utilisateur = new Utilisateur { PersonneId = personne.Id, Mail = mail, MotDePasse = mdp, Adresse = adresse };
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            Professeur professeur = new Professeur { UtilisateurId = utilisateur.Id };
            _bddContext.Professeurs.Add(professeur);
            _bddContext.SaveChanges();
            return professeur.Id;
        }


        //Retourne une string contenant prenom + nom
        public string GetPrenomNom(int profId)
        {
            int utilisateurId = _bddContext.Professeurs.Find(profId).UtilisateurId;
            int personneId = _bddContext.Utilisateurs.Find(utilisateurId).PersonneId;
            Personne laPersonne = _bddContext.Personnes.Find(personneId);

            return laPersonne.Prenom + " " + laPersonne.Nom;
        }

        public int CreerEval(Evaluation eval)
        {
           _bddContext.Evaluations.Add(eval);
            _bddContext.SaveChanges();
           //_bddContext.Reservations.Where(r => r.Id == resaId).FirstOrDefault().EvaluationId = eval.Id;
           // _bddContext.SaveChanges();
           return eval.Id;
        }
          


        // Méthode d'obtention des cours à venir pour un professeur à partir de la liste des réservations
        public List<Reservation> GetCoursFuturs(int professeurId)
        {
            //var query = _bddContext.Reservations.FromSqlRaw("select * from reservations" +
            //" inner join creneaux" +
            //" on creneaux.reservationId = Reservations.Id" +
            //" group by reservationId" +
            //" having creneaux.professeurId = " + professeurId + " and horaire > now()"
            //);

            var query = from r in _bddContext.Reservations
                        join c in _bddContext.Creneaux
                        on r.Id equals c.ReservationId
                        where c.ProfesseurId == professeurId && r.Horaire > DateTime.Now
                        select r;

            // var List = query.Distinct().OrderBy(r => r.Horaire).ToList(); 
            return query.Distinct().OrderBy(r => r.Horaire).ToList();
        }

        // Méthode d'obtention des cours passés pour un professeur à partir de la liste des réservations
        public List<Reservation> GetCoursPasses(int professeurId)
        {
            var query = from r in _bddContext.Reservations
                        join c in _bddContext.Creneaux
                        on r.Id equals c.ReservationId
                        where c.ProfesseurId == professeurId && r.Horaire < DateTime.Now
                        select r;

            return query.Distinct().ToList();
        }

        public void ModifierCreditProf(int professeurId, double montant)
        {
            _bddContext.Professeurs.Find(professeurId).CreditProf += montant;
            _bddContext.SaveChanges();
        }

        public PlanningProf CreerPlanningProf(int professeurId, DateTime jour)
        {
            PlanningProf planning = new PlanningProf() { Jour = jour };
            var query = _bddContext.Creneaux.Where(c => c.ProfesseurId == professeurId).ToList();
            query = query.Where(c => c.Debut.Date == jour.Date).ToList();
            foreach (Creneau c in query)
            {
                int rang = c.Rang();

                if (c.ReservationId == 0) 
                {
                    planning.StatutsCreneaux[rang] = 1;
                }
                else
                {
                    planning.StatutsCreneaux[rang] = 2;
                }
            }
            return planning;
        }


    }

}

