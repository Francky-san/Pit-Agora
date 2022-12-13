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
            DalGen dal = new DalGen();
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Professeur professeur = new Professeur { UtilisateurId = utilisateurId, Matiere1 = matiere1, Matiere2 = matiere2 };
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
