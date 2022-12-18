using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Models
{
    public class DalReservation : IDisposable
    {
        private BddContext _bddContext;
        public DalReservation()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        public List<Creneau> GetCreneaux(int ResaId)
        {
            return _bddContext.Creneaux.Include(c=>c.Professeur).ThenInclude(p=>p.Utilisateur).ThenInclude(u=>u.Personne).Include(c=>c.Reservation).Where(c=>c.ReservationId== ResaId).ToList();
        }

    }
}
