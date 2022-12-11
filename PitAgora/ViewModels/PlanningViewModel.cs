using PitAgora.Models;
using System;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class PlanningViewModel
    {
        public bool[] Dispos { get; set; }
        public string PrenomProf { get; set; }
        public string NomProf { get; set; }
        public string Jour { get; set; }
        public string Matiere { get; set; }

        public PlanningViewModel(string prenomProf, string nomProf, List<Creneau> l, string matiere)
        {
            Dispos = new bool[Creneau.NB_CRENEAUX_PAR_JOUR];
            foreach (Creneau c in l)
            {
                Dispos[c.Rang()] = true;
            }
            PrenomProf = prenomProf;
            NomProf = nomProf;
            DateTime debut = l[0].Debut;
            Jour = Creneau.Jour(debut.DayOfWeek.ToString()) + " " + debut.Day + " " + debut.Month;
            Matiere = matiere;
        }

        // Pour tests
        public PlanningViewModel(string prenomProf, string nomProf, bool[] b)
        {
            Dispos = b;
            PrenomProf = prenomProf;
            NomProf = nomProf;
            DateTime debut = new DateTime(2023, 01, 15);
            Jour = Creneau.Jour(debut.DayOfWeek.ToString()) + " " + debut.Day + " " + Creneau.Mois(debut.Month);
            Matiere = "Maths";
        }

    }

}