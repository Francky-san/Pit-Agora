using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    //ViewModel pour construction des vues parent   
    public class ParentViewModel
    {

        public Eleve Eleve { get; set; }
        public Parent Parent { get; set; }

        public List<Reservation> CoursFuturs { get; set; }

        public List<Reservation> CoursPasses { get; set; }
        public List<Evaluation> Evaluations { get; set; }
       
    }

}
