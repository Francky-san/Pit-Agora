﻿using PitAgora.Models;
using System;
using System.Collections.Generic;
using static PitAgora.Models.Matiere;
using static PitAgora.Models.Niveau;

namespace PitAgora.ViewModels
{
    public class PlanningViewModel
    {
        public int[] Dispos { get; set; }  // représente tous les créneaux de la journée. Une cellule contient l'Id du créneau
                                           // si celui-ci est disponible, 0 sinon
        public List<int> CreneauxDispos { get; set; }  // liste des Id des créneaux disponibles
        public int ProfesseurId { get; set; }
        public string PrenomNomProf { get; set; }
        public DateTime Horaire { get; set; }
        public string Jour { get; set; }   // pour afficher le jour en français
        public MatiereEnum Matiere { get; set; }
        public NiveauEnum Niveau { get; set; }
        public bool EstEnBinom { get; set; }
        public bool EstEnPresentiel { get; set; }

        public PlanningViewModel(List<Creneau> creneaux, int professeurId, DateTime horaire, MatiereEnum matiere, NiveauEnum niveau, bool estEnBinome, 
            bool estEnPresentiel)
        {
            Dispos = new int[Creneau.NB_CRENEAUX_PAR_JOUR];
            CreneauxDispos = new List<int>();
            foreach (Creneau creneau in creneaux)
            {
                Dispos[creneau.Rang()] = creneau.Id;
                CreneauxDispos.Add(creneau.Id);
            }

            DalProf dalP = new DalProf();
            ProfesseurId = professeurId;
            PrenomNomProf = dalP.GetPrenomNom(professeurId);

            DateTime Horaire = horaire;
            Jour = Creneau.Jour(horaire.DayOfWeek.ToString()) + " " + horaire.Day + " " + Creneau.Mois(horaire.Month);
            Matiere = matiere;
            Niveau = niveau;
            EstEnBinom = estEnBinome;
            EstEnPresentiel = estEnPresentiel;
        }

        // Pour tests
        public PlanningViewModel(int id, string prenomProf, string nomProf, int[] dispos)
        {
            ProfesseurId = id;
            Dispos = dispos;
            PrenomNomProf = prenomProf + " " + nomProf;
            DateTime debut = new DateTime(2023, 01, 15);
            Jour = Creneau.Jour(debut.DayOfWeek.ToString()) + " " + debut.Day + " " + Creneau.Mois(debut.Month);
            Matiere = MatiereEnum.maths;
            Niveau = NiveauEnum.terminaleTechno;

        }

    }

}