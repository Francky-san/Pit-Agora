using PitAgora.Models;
using System;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class ProfViewModel
    {
        public Professeur Professeur { get; set; }

        public List<Creneau> CreneauxDisponibles { get; set; }

        public List<Creneau> CreneauxReserves { get; set; }

        public List<Reservation> CoursFuturs { get; set; }

        public List<Reservation> CoursPasses { get; set; }

        public ProfViewModel()
        {
            CreneauxDisponibles = new List<Creneau>();
            CreneauxReserves = new List<Creneau>();
            CoursFuturs = new List<Reservation>();
            CoursPasses = new List<Reservation>();
        }

    }
}
