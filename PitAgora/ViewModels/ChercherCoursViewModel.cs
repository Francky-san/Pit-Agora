using System;
using System.ComponentModel.DataAnnotations;
using PitAgora.Models;

namespace PitAgora.ViewModels
{
    public class ChercherCoursViewModel
    {
        public Eleve Eleve { get; set; }
        public Matiere Matiere { get; set; }
        public Niveau Niveau { get; set; }
        [Display(Name = "Jour")]
        public DateTime DebutJournee { get; set; }
        public bool EstEnPresentiel { get; set; }
        public bool EstEnBinome { get; set; }
        [Display(Name = "Nom")]
        public string NomBinome { get; set; }
        [Display(Name = "Prenom")]
        public string PrenomBinome { get; set; }

    }
}
