using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Collections.Generic;

namespace PitAgora.Controllers
{
    public class EleveController : Controller
    {
        private readonly DalCreneaux dal;

        public EleveController()
        {
            dal = new DalCreneaux();
        }


        public IActionResult AccueilEleve(Eleve eleve)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChercherCours()
        {
            ViewData["messageChercherCours"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult ChercherCours(MatiereEnum matiere, NiveauEnum niveau, DateTime horaire,bool estEnBinome, bool estEnPresentiel)
        {
            string gpeNiveau = Niveau.dictNiveaux[niveau];
            DateTime debutJournee = new DateTime(horaire.Year, horaire.Month, horaire.Day, 0,0,0);
            DateTime finJournee = new DateTime(horaire.Year, horaire.Month, horaire.Day, 23, 59, 59);
            List<Creneau> query = dal.RequeteDistanciel2(matiere, gpeNiveau, debutJournee, finJournee);

            List<PlanningViewModel> lesPlannings = new List<PlanningViewModel>();   // les 5 plannings sélectionnés
            
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
                        lesPlannings.Add(new PlanningViewModel(tempPlanning, tempProfId, horairePrecedent, matiere, niveau, estEnBinome, estEnPresentiel));
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
                ViewData["messageChercherCours"] = "Désolé, pas de disponibilité ce jour-là.";
                return View("ChercherCours");
            }
        }
        
        [HttpPost]  //pour demander confirmation : nouvelle vue ou simple fenêtre pop-up ??
        public IActionResult ConfirmerReservation(int professeurId, string matiere, string niveau, string creneaux, float prix, 
            bool estEnBinome, bool estEnPresentiel)
        {
            /*
            A FAIRE :
            - calculer l'horaire de départ et la durée, à partir de la liste des id des créneaux (méthode dans dalCreneaux)
            - créer l'objet réservation
            View :
            - afficher la réservation
            - Si BINOME, demander le nom du second élève et en déduire son Id
            - demander confirmation de la nouvelle reservation (rappeler la règle concernant une annulation)
            */

            return View();
        }

        [HttpPost]
        public IActionResult CreerReservation(int professeurId, string matiere, string niveau, string creneaux, float prix,
            bool estEnBinome, bool estEnPresentiel)
        {
            /*
            A FAIRE :
            - utiliser CreerReservation pour creer la nouvelle reservation
            */
            Console.WriteLine("Bien arrivé dans la méthode CreerReservation");
            return View("AccueilEleve");
        }

    }
}
