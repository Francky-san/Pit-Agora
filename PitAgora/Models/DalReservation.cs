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

        public int creerReservation(Reservation reservation)
        {
            _bddContext.Reservations.Add(reservation);
            _bddContext.SaveChanges();
            return reservation.Id;
        }
        
        // Affecte une réservation nouvellement créée à un créneau (le créneau devient indisponible)
        public void AffecterACreneau(int reservationId, int creneauId)
        {
            _bddContext.Creneaux.Find(creneauId).ReservationId = reservationId;
            _bddContext.SaveChanges();
        }

        // Affecte une réservation nouvellement créée à un élève (via la table d'association)
        public void AffecterAEleve(int reservationId, int eleveId)
        {
            AReserve ar = new AReserve() { ReservationId = reservationId, EleveId = eleveId };
            _bddContext.AReserve.Add(ar);
            _bddContext.SaveChanges();
        }

        // Retourne la liste des créneaux d'une réservation
        public List<Creneau> GetCreneaux(int ResaId)
        {
            return _bddContext.Creneaux.Include(c=>c.Professeur).ThenInclude(p=>p.Utilisateur).ThenInclude(u=>u.Personne).Include(c=>c.Reservation).Where(c=>c.ReservationId== ResaId).ToList();
        }

    }

}
