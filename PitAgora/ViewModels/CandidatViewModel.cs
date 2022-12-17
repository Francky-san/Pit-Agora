using PitAgora.Models;

namespace PitAgora.ViewModels
{
    public class CandidatViewModel
    {
        public Utilisateur Utilisateur { get; set; }  
        public Personne Personne { get; set; }
        public Professeur Professeur { get; set; }
        public MatiereProf MatiereProf { get; set; }
        public MatiereEnum Matiere { get; set; }
    }
}
