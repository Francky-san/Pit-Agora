using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class ParentViewModel
    {

        public Eleve Eleve { get; set; }
        public Parent Parent { get; set; }
        public List<Creneau> Creneaux { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Evaluation> Evaluations { get; set; }

        //Constructeur pour redirection depuis homecontroller
        public ParentViewModel() { Eleve eleve; Parent parent; }
    }
}
