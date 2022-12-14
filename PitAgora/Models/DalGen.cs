using PitAgora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


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
            string mdp=_bddContext.EncodeMD5(motDePasse);
            Utilisateur utilisateur = new Utilisateur() { PersonneId = id, Mail = mail, MotDePasse = mdp, Adresse = adresse };
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

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return this._bddContext.Utilisateurs.Find(id);
        }

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirUtilisateur(id);
            }
            return null;
        }

        //Methode suivante relatives à authentification et autorisation//////////////////////////////////////////////////
        public Utilisateur Authentifier(string mail, string motDePasse)
        {
            string password = EncodeMD5(motDePasse);
            Utilisateur user = _bddContext.Utilisateurs.FirstOrDefault(u => u.Mail == mail && u.MotDePasse == password);
            return user;
        }
        public string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";

            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
        public void CreerTableNiveaux()
        {
            foreach (string n in Niveau.lesNiveaux)
            {
                Niveau niveau = new Niveau() { Intitule = n };
                _bddContext.Niveaux.Add(niveau);
            }
            _bddContext.SaveChanges();
        }

    }
}
