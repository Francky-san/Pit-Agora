using System.ComponentModel.DataAnnotations;

namespace PitAgora.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
    }

    public enum MatiereEnum
    {
        [Display(Name = "Maths")]
        maths,
        [Display(Name = "Physiques-Chimie")]
        physique,
        [Display(Name = "SVT")]
        svt,
        [Display(Name = "Technologie")]
        techno
    }
}
