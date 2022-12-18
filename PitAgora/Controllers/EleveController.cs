using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Controllers
{
    public class EleveController : Controller
    {
        private readonly DalEleve dalE;
        private readonly DalCreneaux dalC;
        private readonly DalGen dalG;
        private readonly DalProf dalP;
        private readonly DalReservation dalR;

        public EleveController()
        {
            dalE = new DalEleve();
            dalC = new DalCreneaux();
            dalG = new DalGen();
            dalP = new DalProf();
            dalR = new DalReservation();
        }

        [HttpGet]
        public IActionResult AccueilEleve(int id)
        {
            EleveViewModel evm = new EleveViewModel(id);
            return View(evm);
        }

        [HttpGet]
        public IActionResult ChercherCours(int id)
        {
            Eleve lEleve = dalE.ObtenirUnEleve(id); 
            ChercherCoursViewModel ccvm = new ChercherCoursViewModel() { Eleve = lEleve};
            ViewData["messageChercherCours"] = "";
            return View(ccvm);
        }

        [HttpPost]
        public IActionResult ChercherCours(MatiereEnum matiere, NiveauEnum niveau, DateTime debutJournee, bool estEnBinome, bool estEnPresentiel, int eleveId)
        {
            Eleve lEleve = dalE.ObtenirUnEleve(eleveId);
            
            string gpeNiveau = Niveau.dictNiveaux[niveau];
            DateTime finJournee = debutJournee.AddDays(1);
            List<Creneau> query = dalC.RequeteDistanciel2(matiere, gpeNiveau, debutJournee, finJournee);  // requête Bdd

            List<PlanningViewModel> lesPlannings = new List<PlanningViewModel>();   // pour stocker les plannings sélectionnés
            
            int nbCreneaux = query.Count;

            if (query.Count>0)
            {
                int tempProfId = query[0].ProfesseurId;
                List<Creneau> tempPlanning = new List<Creneau>();
                tempPlanning.Add(query[0]);
                DateTime horairePrecedent = query[0].Debut;
                bool planningValide = false;

                int k = 1;
                while (k < nbCreneaux)
                {
                    while (k < nbCreneaux && query[k].ProfesseurId == tempProfId)
                    {
                        if (horairePrecedent.AddMinutes(30).Equals(query[k].Debut))  // le créneau suit le précédent
                        {
                            planningValide = true;
                        }
                        tempPlanning.Add(query[k]);
                        horairePrecedent = query[k].Debut;
                        k++;
                    }
                    if (planningValide)
                    {
                        lesPlannings.Add(new PlanningViewModel(lEleve, tempPlanning, tempProfId, horairePrecedent, matiere, niveau, estEnBinome, estEnPresentiel));
                    }
                    if (lesPlannings.Count == 5)
                    {
                        break;
                    }
                    if (k < nbCreneaux)
                    {
                        tempProfId = query[k].ProfesseurId;
                        tempPlanning = new List<Creneau>();
                        tempPlanning.Add(query[k]);
                        horairePrecedent = query[k].Debut;
                        planningValide = false;
                    }
                }
                return View("ChoisirCours", lesPlannings);
            }
            else
            {
                ChercherCoursViewModel ccvm = new ChercherCoursViewModel() { Eleve = lEleve };
                ViewData["messageChercherCours"] = "Désolé, pas de disponibilité ce jour-là.";
                return View("ChercherCours",ccvm);
            }
        }
        
        [HttpPost]  //pour demander confirmation : nouvelle vue ou simple fenêtre pop-up ??
        public IActionResult CreerReservation(PlanningViewModel pvm, int professeurId, string creneaux, double prix, int eleveId)
        {
            string prenomNomProf = dalP.GetPrenomNom(professeurId);

            List<int> creneauxId = new List<int>();
            int i = 0;
            foreach (string s in creneaux.Split(","))
            {
                if (int.TryParse(s, out i)) {
                    creneauxId.Add(i);
                }
            }
            List<Creneau> lesCreneaux = dalC.listeCreneauxDepuisId(creneauxId).OrderBy(c => c.Debut).ToList();
            DateTime horaire = lesCreneaux[0].Debut;

            string jour = Creneau.JourEnFrancais(horaire);
            int dureeMinutes = 30*lesCreneaux.Count;
            bool estValide = true;
            if (pvm.EstEnBinome) { estValide = false; }

            Reservation laReservation = new Reservation() { PrenomNomProf = prenomNomProf, Horaire = horaire, Jour = jour, DureeMinutes = dureeMinutes, 
                Matiere = pvm.Matiere, Niveau = pvm.Niveau, Prix = prix, EstEnBinome = pvm.EstEnBinome, 
                EstEnPresentiel = pvm.EstEnPresentiel, EstValide = estValide};

            int reservationId = dalR.creerReservation(laReservation);

            // Affecter cette réservation aux créneaux concernés
            foreach (Creneau c in lesCreneaux)
            {
                dalR.AffecterACreneau(reservationId, c);
            }

            // Affecter cette réservation à l'élève concerné
            dalR.AffecterAEleve(reservationId, eleveId);

            EleveViewModel evm = new EleveViewModel(eleveId);

            /*
            A FAIRE :
            - demander confirmation de la nouvelle reservation (rappeler la règle concernant une annulation)
            */
            return View("AccueilEleve", evm);
        }

      
    }
}
