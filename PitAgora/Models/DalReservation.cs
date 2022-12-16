using System;

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

        public int creerReservation(Reservation reservation)
        {
            _bddContext.Reservations.Add(reservation);
            _bddContext.SaveChanges();
            return reservation.Id;
        }
    }
}
