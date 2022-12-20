using System.Collections.Generic;

namespace PitAgora.Models
{
    public class NiveauProf
    {
        //Table intermediaire niveaux et prof
        public int Id { get; set; }
        //FK vers professeur
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; }
        //FK vers niveau
        public int NiveauId { get; set; }
        public Niveau Niveau { get; set; }

    }
}
