using PitAgora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace PitAgora
{
    public class DalEleve : IDisposable
    {
        private BddContext _bddContext;
        public DalEleve()
        {
            _bddContext = new BddContext();
        }

      

        public List<Eleve> ObtientTousLesELeves()
        {
            return _bddContext.Eleves.ToList();
        }
       

        public int CreerEleve(string nom, string prenom, string mail, string motDePasse, string adresse, int creditCours)
        {
            DalGen dal = new DalGen(); 
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Eleve eleve = new Eleve() { UtilisateurId = utilisateurId, CreditCours = creditCours };
            _bddContext.Eleves.Add(eleve);
            _bddContext.SaveChanges(); /*A ne pas oublier, enregistre la modif*/
            return eleve.Id;

        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

    }
}
