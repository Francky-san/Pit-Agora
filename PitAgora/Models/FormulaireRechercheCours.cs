using System;
using System.ComponentModel.DataAnnotations;

namespace PitAgora.Models
{
    public class FormulaireRechercheCours
    {
        public Matiere Matiere { get; set; }
        public Niveau Niveau { get; set; }
        [Display(Name = "Jour")]
        public DateTime DebutJournee { get; set; }
        public bool EstEnPresentiel { get; set; }
        public bool EstEnBinome { get; set; }
        public string NomBinome { get; set; }
        public string PrenomBinome { get; set; }

    }
}
