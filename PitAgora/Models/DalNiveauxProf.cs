﻿using System;

namespace PitAgora.Models
{
    public class DalNiveauxProf : IDisposable
    {
        private BddContext _bddContext;
        public DalNiveauxProf()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        public void CreerNiveauxProf(int profId, int niveauId)
        {
            NiveauProf niveauxProf = new NiveauProf() { ProfesseurId = profId, NiveauId = niveauId };
            _bddContext.NiveauxProfs.Add(niveauxProf);
            _bddContext.SaveChanges();
        }

    }
}
