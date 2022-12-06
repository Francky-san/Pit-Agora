using System;
namespace PitAgora.Models
{
    public class Creneau

    {

        public int Id { get; set; }

        public DateTime Debut { get; set; }

        public Char Statut { get; set; } // D = disponible, A = en attente confirmation binome, P = reservé en presentiel, T = reservé en télépresentiel,  

        public int IdProf { get; set; }

    }
}
