using System;
using System.Collections.Generic;

namespace PitAgora.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Eleve1Id { get; set; }
        public int Eleve2Id { get; set; }
        public int ProfesseurId { get; set; }
        public string Matiere { get; set; }
        public string Niveau { get; set; }
        public DateTime Horaire { get; set; }
        public List<Creneau> Creneaux { get; set; }
        public float Prix { get; set; }
        public bool Binome { get; set; }
        public bool Presentiel { get; set; }
        public bool EstValide { get; set; }

    }
}
