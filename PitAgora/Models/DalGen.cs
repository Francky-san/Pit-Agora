using PitAgora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace PitAgora
{
    public class DalGen : IDisposable
    {
        private BddContext _bddContext;
        public DalGen()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        
        public int CreerPersonne(string nom, string prenom)
        {
            Personne personne = new Personne() { Nom = nom, Prenom = prenom };
            _bddContext.Personnes.Add(personne);
            _bddContext.SaveChanges();
            return personne.Id;
        }

        public int CreerPersonne(Personne personne)
        {
            _bddContext.Personnes.Add(personne);
            _bddContext.SaveChanges();
            return personne.Id;
        }
        public int CreerUtilisateur(int id, string mail, string motDePasse, string adresse)
        {
            Utilisateur utilisateur = new Utilisateur() {PersonneId=id,Mail = mail, MotDePasse = motDePasse, Adresse = adresse };
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }

    


        public List<Personne> ObtientToutesPersonnes()
        {
            return _bddContext.Personnes.ToList();
        }

        public void ModifierPersonne(Personne personne)
        {
            _bddContext.Personnes.Update(personne);
            _bddContext.SaveChanges();
        }
    }
}
