namespace PitAgora.Models
{
    public class MatiereProf
    {
        //Table intermediaire matiere/prof
        public int id { get; set; }
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; }
        public int MatiereId { get; set; }
        public Matiere Matiere { get; set; }
    }
}
