using System;

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

        
    }
}
