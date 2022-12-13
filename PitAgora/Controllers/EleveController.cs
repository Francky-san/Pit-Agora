using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PitAgora.Controllers
{
    public class EleveController : Controller
    {
        private readonly DalCreneaux dal;

        public EleveController()
        {
            dal = new DalCreneaux();
        }


        public IActionResult AccueilEleve()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChercherCours()
        {
            // Test de la méthode TestCalculerDistance()
            DistanceDom.TestCalculerDistance();
            return View();
        }

        [HttpPost]
        public IActionResult ChercherCours(MatiereEnum matiere, NiveauEnum niveau, DateTime horaire,bool estEnBinome, bool estEnPresentiel)
        {
            string gpeNiveau = Niveau.dictNiveaux[niveau];
            DateTime debutJournee = new DateTime(horaire.Year, horaire.Month, horaire.Day, 0,0,0);
            DateTime finJournee = new DateTime(horaire.Year, horaire.Month, horaire.Day, 23, 59, 59);

            using (BddContext ctx = new BddContext())
            {   // rajouter : critère distance pour Présentiel, critère ancienneté pour Distanciel
                var query = from c in ctx.Creneaux
                            join p in ctx.Professeurs on c.ProfesseurId equals p.Id
                            join np in ctx.NiveauxProfs on p.Id equals np.ProfesseurId
                            join n in ctx.Niveaux on np.NiveauId equals n.Id
                            where n.Intitule.Equals(gpeNiveau) && c.Debut.CompareTo(debutJournee) >= 0 && c.Debut.CompareTo(finJournee) < 0 && (p.Matiere1.Equals(matiere) || p.Matiere2.Equals(matiere))
                            orderby p.Id, c.Debut
                            select new { c.ProfesseurId, c.Debut, c.Id };   //  comment limiter à 50 ?

                List<PlanningViewModel> lesPlannings = new List<PlanningViewModel>();

                int tempProfId = 0;
                DateTime horairePrecedent = debutJournee;
                List<List<int>> tempPlages = new List<List<int>>();
                List<int> plageEnCours = new List<int>();
                List<int> creneauxEnCours= new List<int>();

                foreach (var item in query.Take(50).ToList()) {
                    if (item.ProfesseurId == tempProfId)   // Le créneau concerne encore le même professeur
                    {
                        if (!horairePrecedent.AddMinutes(30).Equals(item.Debut))  // le créneau ne suit pas le précédent
                        {
                            plageEnCours = new List<int>();   // on crée une nouvelle plage
                            tempPlages.Add(plageEnCours);
                        }
                        plageEnCours.Add(item.Id);
                        horairePrecedent = item.Debut;
                    }
                    else    // Le créneau concerne un autre professeur
                    {
                        if (PlanningValable(tempPlages, estEnPresentiel))
                        {
                            PlanningViewModel nouveauPlanning = new PlanningViewModel(plageEnCours, tempProfId, horaire, matiere, niveau, estEnBinome, estEnPresentiel);
                        }
                    }
                    {

                    }
                }
                
                // test de la gestion du planning dans la page web
                List<PlanningViewModel> laListe = new List<PlanningViewModel>();
                laListe.Add(new PlanningViewModel(1, "Tata", "Tata", new int[] { 14, 15, 16, 0, 0, 0, 0, 0, 28, 29, 30, 31, 42, 43, 44, 45, 0, 0, 0, 0 }));
                laListe.Add(new PlanningViewModel(2, "Tata", "Tété", new int[] { 0, 0, 0, 0, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 0, 0, 0, 0 }));
                laListe.Add(new PlanningViewModel(3, "Tata", "Titi", new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }));
                laListe.Add(new PlanningViewModel(4, "Tata", "Toto", new int[] { 17, 18, 19, 20, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 23, 24, 25, 26, 27 }));
                laListe.Add(new PlanningViewModel(5, "Tata", "Tutu", new int[] { 32, 33, 34, 0, 0, 0, 0, 35, 36, 37, 38, 0, 0, 0, 0, 0, 39, 40, 41, 0 }));
                return View("ChoisirCours", laListe);
            }
        }

        
        [HttpPost]
        public IActionResult CreerReservation(int professeurId, string matiere, string niveau, string creneaux, float prix, 
            bool estEnBinome, bool estEnPresentiel)
        {
            Console.WriteLine("créneaux : " + creneaux);
            Console.WriteLine("prof : " + professeurId);
            /*
            A FAIRE :
            - calculer l'horaire de départ à partir de la liste des créneaux, non triée (méthode dans dalCreneaux ?)
            - Si BINOME, demander le nom du second élève et en déduire son Id
            - utiliser CreerReservation pour creer la nouvelle reservation
            */
            return View("Index");
        }

        public bool PlanningValable(List<List<int>> listePlages, bool estEnPresentiel)
        {
            return true;
        }

    }
}
