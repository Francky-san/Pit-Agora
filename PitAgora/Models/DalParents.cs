using PitAgora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace PitAgora
{
    public class Dal : IDisposable
    {
        private BddContext _bddContext;
        public Dal()
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

        public List<Eleve> ObtientTousLesELeves()
        {
            return _bddContext.Eleves.ToList();
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

        public int CreerEleve(string nom, string prenom, string mail, string motDePasse, string adresse, int creditCours)
        {
            int personneId=CreerPersonne(nom, prenom);
            int utilisateurId=CreerUtilisateur(personneId,mail, motDePasse, adresse);
            Eleve eleve = new Eleve() {UtilisateurId=utilisateurId,CreditCours = creditCours };
            _bddContext.Eleves.Add(eleve);
            _bddContext.SaveChanges(); /*A ne pas oublier, enregistre la modif*/
            return eleve.Id;

        }

        public List<Professeur> ObtientTousLesProfesseurs()
        {
            return _bddContext.Professeurs.ToList();
        }

        public int CreerProfesseur(string nom, string prenom, string mail, string motDePasse, string adresse, string matiere)
        {
            int personneId = CreerPersonne(nom, prenom);
            int utilisateurId = CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Professeur professeur = new Professeur { UtilisateurId = utilisateurId, Matiere1 = matiere };
            _bddContext.Professeurs.Add(professeur);
            _bddContext.SaveChanges(); /*A ne pas oublier, enregistre la modif*/
            return professeur.Id;

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
