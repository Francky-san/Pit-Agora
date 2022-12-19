using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Models
{
    public class DalEleve : IDisposable
    {
        private BddContext _bddContext;
        public DalEleve()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
        //Méthode de récupération des élèves, jointures utilisateur personne et parent. Sert aussi à construire vue parent
        public List<Eleve> ObtientTousLesELeves()
        {
            return _bddContext.Eleves.Include(e => e.Utilisateur).ThenInclude(u => u.Personne).Include(e => e.Parent).ToList();
        }

        public Eleve ObtenirUnEleve(int id)
        {
            Eleve unEleve = _bddContext.Eleves.Find(id);
            return unEleve;
        }

        public void ModifierPythos(int id, int pythos)
        {
            _bddContext.Eleves.Find(id).CreditPythos += pythos;
            _bddContext.SaveChanges();
        }

        public void ModifierCreditCours(int id, double montant)
        {
            _bddContext.Eleves.Find(id).CreditCours += montant;
            _bddContext.SaveChanges();
        }

        //Méthode pour obtenir la liste des résa d'un élève.
        public List<AReserve> ObtenirReservations(int eleveId)
        {
            return _bddContext.AReserve.Include(ar=>ar.Reservation).ThenInclude(r=>r.Evaluation).Where(ar=>ar.EleveId==eleveId).ToList();
        }

        //Méthode pour obtenir la liste des évaluations d'un élève
        public List<Evaluation> ObtenirEvaluations(int eleveId)
        {
            var query = from r in _bddContext.Reservations
                        join ev in _bddContext.Evaluations on r.EvaluationId equals ev.Id
                        join ar in _bddContext.AReserve on r.Id equals ar.ReservationId
                        join e in _bddContext.Eleves on ar.EleveId equals e.Id
                        where ar.EleveId == eleveId


                        select ev;
            return query.ToList();
        }
        //FT - suppression méthde crééer élève. Doublon inutilisé.
        public int CreerEleve(int parentId, string nom, string prenom, string mail, string motDePasse, string adresse)
        {
            DalGen dal = new DalGen();
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Eleve eleve = new Eleve() { UtilisateurId = utilisateurId, ParentId = parentId, CreditCours = 0, CreditPythos = 0 };
            _bddContext.Eleves.Add(eleve);
            _bddContext.SaveChanges();
            return eleve.Id;
        }

        // Retourne la liste des réservation d'un élève dont la date n'est pas passée (maximum 5)
        public List<Reservation> ObtenirCoursFuturs(int eleveId)
        {
            List<Reservation> res = new List<Reservation>();
            List<AReserve> l = _bddContext.AReserve.Include(ar => ar.Reservation).Where(ar => ar.EleveId == eleveId)
                .Where(ar => ar.Reservation.Horaire > DateTime.Now).Take(5).ToList();
            foreach (AReserve ar in l)
            {
                res.Add(ar.Reservation);
            }
            return res;
        }

        // Retourne la liste des réservation d'un élève dont la date est passée (maximum 5)
        public List<Reservation> ObtenirCoursPasses(int eleveId)
        {
            List<Reservation> res = new List<Reservation>();
            List<AReserve> l = _bddContext.AReserve.Include(ar => ar.Reservation).Where(ar => ar.EleveId == eleveId)
                .Where(ar => ar.Reservation.Horaire < DateTime.Now).Take(5).ToList();
            foreach (AReserve ar in l)
            {
                res.Add(ar.Reservation);
            }
            return res;
        }

        //Retourne une string contenant prenom 
        public string GetPrenom(int eleveId)
        {
            int utilisateurId = _bddContext.Eleves.Find(eleveId).UtilisateurId;
            int personneId = _bddContext.Utilisateurs.Find(utilisateurId).PersonneId;
            Personne laPersonne = _bddContext.Personnes.Find(personneId);

            return laPersonne.Prenom ;
        }

        // Retourne la liste des réservation d'un élève dont la date n'est pas passée
        public List<Reservation> ObtenirCoursFuturs(int eleveId)
        {
            List<Reservation> res = new List<Reservation>();
            List<AReserve> l = ObtenirReservations(eleveId).Where(ar => ar.Reservation.Horaire > DateTime.Now).ToList();
            foreach (AReserve ar in l)
            {
                res.Add(ar.Reservation);
            }
            return res;
        }

        // Retourne la liste des réservation d'un élève dont la date n'est pas passée (maximum 5)
        public List<Reservation> ObtenirCoursPasses(int eleveId)
        {
            List<Reservation> res = new List<Reservation>();
            List<AReserve> l = ObtenirReservations(eleveId).Where(ar => ar.Reservation.Horaire < DateTime.Now).ToList();

            foreach (AReserve ar in l)
            {
                res.Add(ar.Reservation);
            }
            return res;
        }
    }
}
