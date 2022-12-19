using PitAgora.Models;
using System;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class GererPlanningViewModel
    {
        public Professeur Professeur { get; set; }


        public List<PlanningProf> PlanningSemaine { get; set; }

        public GererPlanningViewModel()
        {
            PlanningSemaine = new List<PlanningProf>();
        }
    }
}
