using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class ReservationViewModel

    {
        public Eleve Eleve { get; set; }
        public Reservation Reservation { get; set; }

        public ReservationViewModel()
        {

        }

        public ReservationViewModel(int eleveId)
        {
            DalEleve dalE = new DalEleve();
            Eleve = dalE.ObtenirUnEleve(eleveId);
        }


    }
}
