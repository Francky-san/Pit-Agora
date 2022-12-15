using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class ParentViewModel
    {

        public Eleve Eleve { get; set; }
        public Parent Parent { get; set; }
        public List<Reservation> Reservations { get; set; }
        //Constructeur
        public ParentViewModel() { Eleve eleve; Parent parent; }
    }
}
