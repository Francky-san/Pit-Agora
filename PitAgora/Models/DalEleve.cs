﻿using Microsoft.EntityFrameworkCore;
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

        public void Dispose()
        {
            _bddContext.Dispose();
        }
        //Méthode de récupération des élèves, jointures utilisateur personne et parent. Sert aussi à construire vue parent
        public List<Eleve> ObtientTousLesELeves()
        {
            return _bddContext.Eleves.Include(e=>e.Utilisateur).ThenInclude(u=>u.Personne).Include(e=>e.Parent).ToList();
        }

        public int CreerEleve(string nom, string prenom, string mail, int parentId, string motDePasse, string adresse, int creditCours)
        {
            DalGen dal = new DalGen();
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Eleve eleve = new Eleve() { UtilisateurId = utilisateurId, CreditCours = creditCours };
            _bddContext.Eleves.Add(eleve);
            _bddContext.SaveChanges();
            return eleve.Id;
        }

        public int CreerEleve(int parentId, string nom, string prenom, string mail, string motDePasse, string adresse)
        {
            DalGen dal = new DalGen();
            int personneId = dal.CreerPersonne(nom, prenom);
            int utilisateurId = dal.CreerUtilisateur(personneId, mail, motDePasse, adresse);
            Eleve eleve = new Eleve() { UtilisateurId = utilisateurId, ParentId = parentId, CreditCours = 0, CreditPythos = 0 };
            _bddContext.Eleves.Add(eleve);
            _bddContext.SaveChanges();
            return eleve.Id;

        }

    }
}
