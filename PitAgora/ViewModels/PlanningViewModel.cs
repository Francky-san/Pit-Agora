using PitAgora.Models;
using System;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class PlanningViewModel
    {
        public bool[] Dispos { get; set; }
        public string NomProf { get; set; }

        public PlanningViewModel(string nomProf, List<Creneau> l)
        {
            Dispos = new bool[Creneau.NB_CRENEAUX_PAR_JOUR];
            foreach (Creneau c in l)
            {
                Dispos[c.Rang()] = true;
            }
            NomProf = nomProf;
        }
        public PlanningViewModel(string nomProf, bool[] b)
        {
            Dispos = b;
            NomProf = nomProf;
        }

    }

}