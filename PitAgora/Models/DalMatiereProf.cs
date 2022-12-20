using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Models
{
    public class DalMatiereProf : IDisposable
    {
        private BddContext _bddContext;
        public DalMatiereProf()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
        /*
        public void CreerMatiereProf(int profId, int matiereId)
        {
            MatiereProf matiereProf = new MatiereProf() { ProfesseurId = profId, MatiereId = matiereId };
            _bddContext.MatiereProfs.Add(matiereProf);
            _bddContext.SaveChanges();
        }*/

        public List<Matiere> GetMatiereProf(int profId)
        {
            var query = from m in _bddContext.Matieres
                        join mp in _bddContext.MatieresProfs on m.Id equals mp.MatiereId
                        join p in _bddContext.Professeurs on mp.ProfesseurId equals p.Id
                        select m;

            return query.ToList();
        }
    }
}
