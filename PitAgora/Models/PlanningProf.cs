using System;

namespace PitAgora.Models
{
    public class PlanningProf
    {
        public DateTime Jour { get; set; }

        public int[] IdCreneaux { get; set; }
        public int[] StatutsCreneaux { get; set; }
        // 0 = Non proposé, 1 = Disponible, 2 = Réservé, 3 = à évaluer

        public PlanningProf()
        {
            IdCreneaux = new int[20];
            StatutsCreneaux = new int[20];
        }
    }
}
