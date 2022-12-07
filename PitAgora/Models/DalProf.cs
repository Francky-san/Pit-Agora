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
        public DalProf()
        {
            _bddContext = new BddContext();
        }

        public List<Professeur> ObtientTousLesProfesseurs()
        {
            return _bddContext.Professeurs.ToList();
        }

        public int CreerProfesseur(string nom, string prenom, string mail, string motDePasse, string adresse, string matiere)
        {
            DalGen dal = new DalGen();
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Professeur professeur = new Professeur { UtilisateurId = utilisateurId, Matiere1 = matiere };
            _bddContext.Professeurs.Add(professeur);
            _bddContext.SaveChanges(); /*A ne pas oublier, enregistre la modif*/
            return professeur.Id;

        }




        public void Dispose()
        {
            _bddContext.Dispose();
        }

    }
}
