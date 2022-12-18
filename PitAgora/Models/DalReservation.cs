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
            return _bddContext.Creneaux.Where(c => c.ReservationId == ResaId).ToList();
        }

        public List<Reservation> GetCoursFuturs(int professeurId)
        {
            return _bddContext.Creneaux.Where(c => c.ProfesseurId == professeurId).Where(c => c.ReservationId != null).Where(C => C.Debut > DateTime.Today).ToList();
        }

        public List<Reservation> GetCoursPasses(int professeurId)
        {
            return _bddContext.Creneaux.Where(c => c.ProfesseurId == professeurId).Where(c => c.ReservationId != null).Where(C => C.Debut < DateTime.Today).ToList();
        }


    }

}
