using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


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

        //Méthode création d'un profeseur
        public int CreerProfesseur(string nom, string prenom, string mail, string motDePasse, string adresse, string matiere1, string matiere2 = "")
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

        //Méthode pour obtenir la liste des créneaux disponibles d'un prof
        public List<Creneau> ListCreneaux(int profId)
        {
            return _bddContext.Creneaux.Include(c => c.Professeur).ThenInclude(p => p.Utilisateur).ThenInclude(u => u.Personne).Include(c => c.Reservation).Where(c => c.ProfesseurId == profId).ToList();
        }

        //Méthode pour obtenir la liste des créneaux réservés d'un prof
        public List<Reservation> ObtenirReservations(int profId)
        {
            var query = from r in _bddContext.Reservations
                        join c in _bddContext.Creneaux on r.Id equals c.ReservationId
                        join p in _bddContext.Professeurs on c.Id equals p.Id
                        where c.ProfesseurId == p.Id
                        select r
                               ;
            return query.ToList();
        }

        

        //public int CreneauAAjouter(Creneau creneau)
        //{
        //    if Id !==.    Where(c => c.ReservationId !== 0)

        //     int personneId = dal.CreerPersonne(nom, prenom);
        //int creneauId =  { Debut = debut, ProfesseurId = professeurId };
        //_bddContext.Creneaux.Add(creneau);
        //_bddContext.SaveChanges();
        //return creneau.Id;
    }

      
   

}

