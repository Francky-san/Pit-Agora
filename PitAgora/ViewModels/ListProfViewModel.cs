using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class ListProfViewModel
    {
        public List<Professeur> profs { get; set; }
        public List<Matiere> matieres { get; set; }
        public List<Niveau> niveaux { get; set; }

    }
}
