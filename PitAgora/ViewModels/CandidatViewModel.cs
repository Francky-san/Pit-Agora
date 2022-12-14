using PitAgora.Models;
using System.IO;

namespace PitAgora.ViewModels
{
    public class CandidatViewModel
    {
        public Utilisateur Utilisateur { get; set; }  
        public Personne Personne { get; set; }
        public Professeur Professeur { get; set; }
        public MatiereProf MatiereProf { get; set; }
        public MatiereEnum Matiere { get; set; }
        public NiveauProf NiveauProf { get; set; }
        public Niveau Niveau { get; set; }
    }
}
