using System;

namespace PitAgora.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int EleveId { get; set; }
        public int ProfesseurId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
