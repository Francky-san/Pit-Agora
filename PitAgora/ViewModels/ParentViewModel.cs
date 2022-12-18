using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class ParentViewModel
    {

        public Eleve Eleve { get; set; }
        public Parent Parent { get; set; }

        public List<Creneau> Creneaux { get; set; }

        public List<AReserve> Reservations { get; set; }

        //Constructeur pour redirection depuis homecontroller
        public ParentViewModel() { Eleve eleve; Parent parent; }
    }
}
