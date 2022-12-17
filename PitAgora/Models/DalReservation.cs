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

        public int creerReservation(Reservation reservation)
        {
            _bddContext.Reservations.Add(reservation);
            _bddContext.SaveChanges();
            return reservation.Id;
        }

        // Affecte une réservation nouvellement créée à un créneau (le créneau devient indisponible)
        public void AffecterACreneau(int reservationId, Creneau c)
        {
            _bddContext.Creneaux.Find(c.Id).ReservationId = reservationId;
            _bddContext.SaveChanges();
        }

        // Affecte une réservation nouvellement créée à un élève (via la table d'association)
        public void AffecterAEleve(int reservationId, Eleve e)
        {
            AReserve ar = new AReserve() { ReservationId = reservationId, Eleve = e };
            _bddContext.AReserve.Add(ar);
            _bddContext.SaveChanges();
        }

        public List<Creneau> GetCreneaux(int ResaId)
        {
            return _bddContext.Creneaux.Where(c => c.ReservationId == ResaId).ToList();
        }


    }
}
