using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class ProfViewModel
    {
        public List<Creneau> Creneaux { get; set; }

        public List<Reservation> Reservations { get; set; }

        public Eleve Eleve { get; set; }
        public List<Evaluation> Evaluations { get; set; }


        //Constructeur pour redirection depuis homecontroller
        public ProfViewModel() { Eleve eleve; }

    }
}
