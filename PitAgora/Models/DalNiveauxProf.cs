using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            NiveauxProf niveauxProf = new NiveauxProf() { ProfesseurId = profId, NiveauId = niveauId };
            _bddContext.NiveauxProfs.Add(niveauxProf);
            _bddContext.SaveChanges();
        }

        public List<Niveau> GetNiveauxProf(int profId)
        {
            var query = from n in _bddContext.Niveaux
                        join nv in _bddContext.NiveauxProfs on n.Id equals nv.NiveauId
                        join p in _bddContext.Professeurs on nv.ProfesseurId equals p.Id
                        select n;

            return query.ToList();
        }
    }
}
