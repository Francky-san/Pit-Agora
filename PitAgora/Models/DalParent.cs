using PitAgora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace PitAgora
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

        public int CreerParent(string nom, string prenom, string mail, string motDePasse, string adresse)
        {
            DalGen dal = new DalGen();
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Parent parent = new Parent() { UtilisateurId = utilisateurId};
            _bddContext.Parents.Add(parent);
            _bddContext.SaveChanges();
            return parent.Id;
        }

    }
}
