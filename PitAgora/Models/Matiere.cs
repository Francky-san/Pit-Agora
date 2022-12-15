using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PitAgora.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public MatiereEnum Intitule { get; set; }
    }
    public enum MatiereEnum
    {
        [Display(Name = "Maths")]
        maths = 1,
        [Display(Name = "Physiques-Chimie")]
        physique,
        [Display(Name = "SVT")]
        svt,
        [Display(Name = "Technologie")]
        techno
    }
}
