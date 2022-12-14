using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Models
{
    public class DalCreneaux : IDisposable
    {
        private BddContext _bddContext;
        public DalCreneaux()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        public int CreerCreneau(DateTime debut, int profId)
        {
            Creneau creneau = new Creneau() { Debut=debut, ProfesseurId=profId};
            _bddContext.Creneaux.Add(creneau);
            _bddContext.SaveChanges();
            return creneau.Id;
        }

        public Creneau GetCreneau(int id)
        {
            return _bddContext.Creneaux.Find(id);
        }

        public List<Creneau> RequeteDistanciel(MatiereEnum matiere, string niveau, DateTime debut, DateTime fin)
        {
            // une requête par le bddContext est-elle possible quand elle implique une relation 'plusieurs à plusieurs' ?
            var query = from c in _bddContext.Creneaux
                        join p in _bddContext.Professeurs on c.ProfesseurId equals p.Id
                        join np in _bddContext.NiveauxProfs on p.Id equals np.ProfesseurId
                        join n in _bddContext.Niveaux on np.NiveauId equals n.Id
                        //where c.Id.CompareTo(8) >= 0
                        where n.Intitule.Equals(niveau) && c.Debut.CompareTo(debut) >= 0 && c.Debut.CompareTo(fin) < 0 //&& (p.Matiere1.Equals(matiere) || p.Matiere2.Equals(matiere))
                        orderby p.Id, c.Debut
                        select c;
                        //select new { c.ProfesseurId, c.Debut, c.Id };
            //var query = _bddContext.Creneaux.Where(c => c.Id >= 8);
            return query.Take(50).ToList();
        }
        
    }
}
