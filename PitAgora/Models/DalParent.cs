using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Models
{
    public class DalParent : IDisposable
    {
        private BddContext _bddContext;
        public DalParent()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        //Méthode récupérer liste complète des professeurs avec jointures utilisateur et personne pour accèder à tous les attributs
        public List<Parent> ObtientTousLesParents()
        {

            return _bddContext.Parents.Include(pa => pa.Utilisateur).ThenInclude(u => u.Personne).ToList();

        }
        public Parent ObtiensUnParent(int id)
        {
            Parent unParent = _bddContext.Parents.Find(id);
            return unParent;
        }

        public int CreerParent(string nom, string prenom, string mail, string motDePasse, string adresse)
        {
            DalGen dal = new DalGen();
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Parent parent = new Parent() { UtilisateurId = utilisateurId };
            _bddContext.Parents.Add(parent);
            _bddContext.SaveChanges();
            return parent.Id;
        }

        //Méthode crediter porte monnaie eleve
        public void CrediterEleve(int montant, int eleveId)
        {
            DalEleve dal = new DalEleve();
            Eleve monEleve = dal.ObtientTousLesELeves().Where(e => e.Id == eleveId).FirstOrDefault();
            monEleve.CreditCours = monEleve.CreditCours+montant;
           _bddContext.SaveChanges()
        }
        //Méthode récupérer un élève à partir de l'id du parent // Pb pour un parent qui a deux élèves.
        public Eleve GetEleve(int parentId)
        {
            return _bddContext.Eleves.Where(e=>e.ParentId == parentId).FirstOrDefault();
        }
    }
}
