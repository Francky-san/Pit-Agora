using System;
using System.Collections.Generic;

namespace PitAgora.Models
{
    public class Creneau

    {
        public static readonly int NB_CRENEAUX_PAR_JOUR = 20;

        public int Id { get; set; }

        public DateTime Debut { get; set; }

        public int ProfId { get; set; }

        public int? ReservationId { get; set; }

        public virtual Reservation reservation { get; set; }



        // ***************** Méthodes *********************

        // Renvoie le rang du créneau dans un planing (9:00-9:30 -> 0)
        public int Rang()
        {
            return 2 * Debut.Hour + (Debut.Minute / 30) - 18;
        }

        // Convertit une liste de créneaux (même prof / même jour) en un tableau de booléens pour avoir les disponibilités sur la journée
        public bool[] PlanningBool(List<Creneau> creneauList)
        {
            bool[] res = new bool[NB_CRENEAUX_PAR_JOUR];
            foreach (Creneau c in creneauList)
            {
                res[c.Rang()] = true;
            }
            return res;
        }
    }
}
