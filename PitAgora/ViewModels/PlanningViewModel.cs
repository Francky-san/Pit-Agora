using PitAgora.Models;
using System;
using System.Collections.Generic;

namespace PitAgora.ViewModels
{
    public class PlanningViewModel
    {
        public bool[] Dispos { get; set; }
        public List<int> CreneauxDispos { get; set; }  // liste des Id des créneaux disponibles
        public int ProfesseurId { get; set; }
        public string PrenomProf { get; set; }
        public string NomProf { get; set; }
        public string Jour { get; set; }   // pour afficher le jour en français
        public DateTime Horaire { get; set; }
        public string Matiere { get; set; }
        public bool EstEnBinom { get; set; }
        public bool EstEnPresentiel { get; set; }

        public PlanningViewModel(List<int> creneaux, int professeurId, DateTime horaire, string matiere, bool estEnBinome, bool estEnPresentiel)
        {
            Dispos = new bool[Creneau.NB_CRENEAUX_PAR_JOUR];
            foreach (int creneauId in creneaux)
            {
                Creneau creneau = DalCreneaux.GetCreneau(creneauId);
                Dispos[creneau.Rang()] = true;
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