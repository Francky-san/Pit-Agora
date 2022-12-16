using PitAgora.Models;

namespace PitAgora.ViewModels
{
    public class InscriptionViewModel
    {
        public Utilisateur Utilisateur { get; set; }
        public Personne Personne { get; set; }
        public Parent Parent { get; set; }
        public Eleve Eleve { get; set; }

    }
}
