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

        // Retourne la liste des créneaux d'une réservation
        public List<Creneau> GetCreneaux(int ResaId)
        {
            return _bddContext.Creneaux.Where(c => c.ReservationId == ResaId).ToList();
        }

        // Retourne la liste des réservation d'un élève dont la date n'est pas passée
        public List<Reservation> ObtenirCoursFuturs(int eleveId)
        {
            List<Reservation> res = new List<Reservation>();
            List<AReserve> l = _bddContext.AReserve.Include(ar => ar.Reservation).Where(ar => ar.EleveId == eleveId)
                .Where(ar => ar.Reservation.Horaire > DateTime.Now).ToList();
            foreach (AReserve ar in l)
            {
                res.Add(ar.Reservation);
            }
            return res;
        }

        public List<Reservation> ObtenirCoursPasses(int eleveId)
        {
            List<Reservation> res = new List<Reservation>();
            List<AReserve> l = _bddContext.AReserve.Include(ar => ar.Reservation).Where(ar => ar.EleveId == eleveId)
                .Where(ar => ar.Reservation.Horaire < DateTime.Now).ToList();
            foreach (AReserve ar in l)
            {
                res.Add(ar.Reservation);
            }
            return res;
        }
    }
}
