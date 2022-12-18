
using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class EleveViewModel
    {
        public Eleve Eleve { get; set; }
        public List<Reservation> CoursFuturs { get; set; }
        public List<Reservation> CoursPasses { get; set; }

        public EleveViewModel()
        {
            CoursFuturs = new List<Reservation>();
            CoursPasses = new List<Reservation>();

        }

    }
}
