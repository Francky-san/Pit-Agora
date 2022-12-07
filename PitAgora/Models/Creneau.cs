using System;
namespace PitAgora.Models
{
    public class Creneau

    {

        public int Id { get; set; }

        public DateTime Debut { get; set; }

        public bool EstDisponible { get; set; }

        public int ProfId { get; set; }

    }
}
