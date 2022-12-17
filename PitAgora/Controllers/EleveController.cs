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
        public IActionResult ChercherCours(MatiereEnum matiere, NiveauEnum niveau, DateTime debutJournee, bool estEnBinome, bool estEnPresentiel, int eleveId)
        {
            string gpeNiveau = Niveau.dictNiveaux[niveau];
            DateTime finJournee = debutJournee.AddDays(1);
            List<Creneau> query = dal.RequeteDistanciel2(matiere, gpeNiveau, debutJournee, finJournee);

            List<PlanningViewModel> lesPlannings = new List<PlanningViewModel>();   // les plannings sélectionnés
            
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
        public IActionResult CreerReservation(PlanningViewModel pvm, int professeurId, string creneaux, double prix)
        {
            DalProf dalP = new DalProf();
            string prenomNomProf = dalP.GetPrenomNom(professeurId);

            List<int> creneauxId = new List<int>();
            int i = 0;
            foreach (string s in creneaux.Split(","))
            {
                if (int.TryParse(s, out i)) {
                    creneauxId.Add(i);
                }
            }
            List<Creneau> lesCreneaux = dal.listeCreneauxDepuisId(creneauxId).OrderBy(c => c.Debut).ToList();
            DateTime horaire = lesCreneaux[0].Debut;

            string jour = Creneau.JourEnFrancais(horaire);
            int dureeMinutes = 30*lesCreneaux.Count;
            bool estValide = true;
            if (pvm.EstEnBinome) { estValide = false; }

            Reservation laReservation = new Reservation() { PrenomNomProf = prenomNomProf, Horaire = horaire, Jour = jour, DureeMinutes = dureeMinutes, 
                Matiere = pvm.Matiere, Niveau = pvm.Niveau, Prix = prix, EstEnBinome = pvm.EstEnBinome, 
                EstEnPresentiel = pvm.EstEnPresentiel, EstValide = estValide};

            DalReservation dalR = new DalReservation();
            int reservationId = dalR.creerReservation(laReservation);

            // Affecter cette réservation aux créneaux concernés
            foreach (Creneau c in lesCreneaux)
            {
                dalR.AffecterACreneau(reservationId, c);
            }

            DalGen dalG = new DalGen();
            // Affecter cette réservation à l'élève concerné
            Utilisateur utilisateur = dalG.ObtenirUtilisateur(HttpContext.User.Identity.Name);
            //Eleve utilisateurConnecte = ??
            //dalR.AffecterAEleve(reservationId, utilisateurConnecte);

            /*
            A FAIRE :
            - demander confirmation de la nouvelle reservation (rappeler la règle concernant une annulation)
            - affecter cette réservation à l'élève concerné
            */
            return View("AccueilEleve");
        }

      
    }
}
