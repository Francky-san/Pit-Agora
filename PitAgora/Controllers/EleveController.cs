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


        //public IActionResult AccueilEleve(int Id)
        //{
        //    DalEleve dal = new DalEleve();
        //    Eleve eleve = dal.ObtientTousLesELeves().Where(e => e.Id == Id).FirstOrDefault();
        //    return View(eleve);
        //}
        public IActionResult Agora()
        {
            return View();
        }

        //Méthode get page d'accueil élève
        [HttpGet]
        public IActionResult AccueilEleve(int id)
        {
            EleveViewModel evm = new EleveViewModel(id);
            return View(evm);
        }

        //Méthode get recherche d'un cours
        [HttpGet]
        public IActionResult ChercherCours(int id)
        {
            Eleve lEleve = dalE.ObtenirUnEleve(id); 
            ChercherCoursViewModel ccvm = new ChercherCoursViewModel() { Eleve = lEleve};
            ViewData["messageChercherCours"] = "";
            return View(ccvm);
        }

        //Méthode post recherche d'un cours, prends les critères de recherche en arguments
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
        
        // Méthode pour créer une réservation
        [HttpPost]
        public IActionResult CreerReservation(PlanningViewModel pvm, int professeurId, string creneaux, double prix, int eleveId)
        {
            // Dhaines pour affichage
            string prenomNomProf = dalP.GetPrenomNom(professeurId);
            string prenomNomEleve = dalE.GetPrenom(eleveId);
            
            // Créneaux associés (pour tri)
            List<int> creneauxId = new List<int>();
            int i = 0;
            foreach (string s in creneaux.Split(","))
            {
                if (int.TryParse(s, out i)) {
                    creneauxId.Add(i);
                }
            }
            List<Creneau> lesCreneaux = dalC.listeCreneauxDepuisId(creneauxId).OrderBy(c => c.Debut).ToList();

            // Heure de début et durée
            DateTime horaire = dalC.GetCreneau(creneauxId[0]).Debut;
            string jour = Creneau.JourEnFrancais(horaire);
            int dureeMinutes = 30*lesCreneaux.Count;

            // estValide : false pour un binôme, en attente de la confirmation du binôme
            bool estValide = true;
            if (pvm.EstEnBinome) { estValide = false; }

            // Création de la réservation
            Reservation laReservation = new Reservation() { PrenomNomProf = prenomNomProf, PrenomEleve = prenomNomEleve, 
                Horaire = horaire, Jour = jour, DureeMinutes = dureeMinutes, 
                Matiere = pvm.Matiere, Niveau = pvm.Niveau, Prix = prix, EstEnBinome = pvm.EstEnBinome, 
                EstEnPresentiel = pvm.EstEnPresentiel, EstValide = estValide};

            int reservationId = dalR.creerReservation(laReservation);

            // Affecter cette réservation aux créneaux concernés
            foreach (int creneauId in creneauxId)
            {
                dalR.AffecterACreneau(reservationId, creneauId);
            }

            // Affecter cette réservation à l'élève concerné
            dalR.AffecterAEleve(reservationId, eleveId);

            // MaJ  créditCours
            dalE.ModifierCreditCours(eleveId, -prix);

            return Redirect("AccueilEleve/"+eleveId);
        }

      
    }
}
