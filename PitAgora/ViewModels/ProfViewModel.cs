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
            CoursFuturs = new List<Reservation>();
            CoursPasses = new List<Reservation>();
            CreneauxDisponibles = new List<Creneau>();
            CreneauxReserves = new List<Creneau>();
        }



        //Constructeur pour redirection depuis homecontroller 
        ////////////////////////////////////////////////////////////////////////
        ///////////////////// A VOIR AVEC FRANCK .....//////////////////////////
        ////////////////////////////////////////////////////////////////////////

        // public ProfViewModel() { Eleve eleve; Professeur professeur; }

    }
}
