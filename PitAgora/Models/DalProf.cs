using Microsoft.EntityFrameworkCore;
using PitAgora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace PitAgora
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
            return _bddContext.Professeurs.Include(p=>p.Utilisateur).ThenInclude(u=>u.Personne).ToList();
        }

        //Méthode création d'un profeseur
        public int CreerProfesseur(string nom, string prenom, string mail, string motDePasse, string adresse, string matiere1, string matiere2="")
        {
<<<<<<< HEAD
<<<<<<< HEAD
            string mdp = _bddContext.EncodeMD5(motDePasse);
            Personne personne = new Personne { Nom = nom, Prenom = prenom };
            _bddContext.Personnes.Add(personne);
            _bddContext.SaveChanges();
            Utilisateur utilisateur = new Utilisateur {PersonneId=personne.Id,Mail= mail,MotDePasse= mdp, Adresse = adresse };
=======
=======
>>>>>>> da68669f75ba9138d8fe2df4863f76cb4badb97f
            _bddContext.EncodeMD5(motDePasse);
            Personne personne = new Personne { Nom = nom, Prenom = prenom };
            _bddContext.Personnes.Add(personne);
            _bddContext.SaveChanges();
            Utilisateur utilisateur = new Utilisateur {PersonneId=personne.Id,Mail= mail,MotDePasse= motDePasse, Adresse = adresse };
<<<<<<< HEAD
>>>>>>> da68669 (Commit avant intégration layout MK)
=======
>>>>>>> da68669f75ba9138d8fe2df4863f76cb4badb97f
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            Professeur professeur = new Professeur { UtilisateurId = utilisateur.Id, Matiere1 = matiere1, Matiere2 = matiere2 };
            _bddContext.Professeurs.Add(professeur);
            _bddContext.SaveChanges();
            return professeur.Id;
        }

        //Méthode de récupération de l'attribut prenom et nom d'un professeur 
        public string GetPrenomNom(int profId)
        {
            Personne p = _bddContext.Professeurs.Find(profId).Utilisateur.Personne;
            return p.Prenom + " " + p.Nom;
        }


    }
}
