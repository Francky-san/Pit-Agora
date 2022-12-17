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

        //Méthode pour obtenir la liste des résa d'un élève.
        public List<Reservation> ObtenirReservations(int eleveId)
        {
            var query = from r in _bddContext.Reservations
                        join ar in _bddContext.AReserve on r.Id equals ar.ReservationId
                        join e in _bddContext.Eleves on ar.EleveId equals e.Id
                        where ar.EleveId == eleveId


                        select r;
            return query.ToList();
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

    }
}
