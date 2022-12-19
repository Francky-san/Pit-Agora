using System;

namespace PitAgora.Models
{
    public class PlanningProf
    {
        public DateTime Jour { get; set; }

        public int[] StatutsCreneaux { get; set; }
        // 0 = Non proposé, 1 = Disponible, 2 = Réservé

        public PlanningProf()
        {
            StatutsCreneaux = new int[20];
        }
    }
}
