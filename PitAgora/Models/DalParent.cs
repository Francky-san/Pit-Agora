using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
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

    }
}
