using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PitAgora.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Eleve1Id { get; set; }
        public virtual Eleve Eleve1 { get; set; }
        public int Eleve2Id { get; set; }
        public virtual Eleve Eleve2 { get; set; }
        public int ProfesseurId { get; set; }

        public MatiereEnum Matiere { get; set; }
        public NiveauEnum Niveau { get; set; }

        public DateTime Horaire { get; set; }
        public List<Creneau> Creneaux { get; set; }
        public float Prix { get; set; }
        public bool Binome { get; set; }
        public bool Presentiel { get; set; }
        public bool EstValide { get; set; }
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
    public enum NiveauEnum
    {
        [Display(Name = "6ème")]
        sixieme,
        [Display(Name = "5ème")]
        cinquieme,
        [Display(Name = "4ème")]
        quatrieme,
        [Display(Name = "3ème")]
        troisieme,
        [Display(Name = "2nde")]
        seconde,
        [Display(Name = "1ère Générale")]
        premiereGenerale,
        [Display(Name = "1ère Techno")]
        premiereTechno,
        [Display(Name = "Terminale Générale")]
        terminaleGenerale,
        [Display(Name = "Terminale Techno")]
        terminaleTechno

    }


}
