using System;

namespace PitAgora.Models
{
    public class FormulaireRechercheCours
    {
        public Matiere Matiere { get; set; }
        public Niveau Niveau { get; set; }
        public DateTime Horaire { get; set; }
        public bool EstEnPresentiel { get; set; }
        public bool EstEnBinome { get; set; }
        public string NomBinome { get; set; }
        public string PrenomBinome { get; set; }

    }
}
