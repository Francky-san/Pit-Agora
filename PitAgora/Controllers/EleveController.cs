using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult Index()
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
        public IActionResult ChercherCours(string matiere, string niveau, DateTime horaire, bool estEnBinome, bool estEnPresentiel)
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
                List<int> plageEncours = new List<int>();
                List<Creneau> creneauxEnCours= new List<Creneau>();

                foreach (var item in query.ToList()) {
                    if (item.ProfesseurId == tempProfId)   // Le créneau concerne encore le même professeur
                    {
                        if (!horairePrecedent.AddMinutes(30).Equals(item.Debut))  // le créneau ne suit pas le précédent
                        {
                            plageEncours = new List<int>();   // on crée une nouvelle plage
                            tempPlages.Add(plageEncours);
                        }
                        plageEncours.Add(item.Id);
                        horairePrecedent = item.Debut;
                    }
                    else    // Le créneau concerne encore un autre professeur
                    {
                        if (planningValable(tempPlages, estEnPresentiel))
                        {
                            PlanningViewModel nouveauPlanning = new PlanningViewModel();
                        }
                    }
                    {

                    }
                    {

                    }
                }
                
                
                // test de la gestion du planning dans la page web
                List<PlanningViewModel> laListe = new List<PlanningViewModel>();
                laListe.Add(new PlanningViewModel("Tata", "Tata", new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Tata", "Tété", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Tata", "Titi", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Tata", "Toto", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Tata", "Tutu", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                return View("ChoisirCours", laListe);
            }
        }


        [HttpGet]
        public IActionResult CreerReservation()
        {
            return View();

        }/*
        [HttpPost]
        public IActionResult CreerReservation(int eleve1Id, int professeurId, string matiere, string niveau, DateTime horaire,
            List<Creneau> creneaux, bool binome, bool presentiel, int eleve2Id = 0)
        {
            BddContext ctx = new BddContext();
            Reservation resa = new Reservation() { Eleve1Id = eleve1Id, Eleve2Id = eleve2Id, ProfesseurId = professeurId,
                Matiere = matiere, Niveau = niveau, Horaire = horaire, Binome = binome, Presentiel = presentiel };
            ctx.Add(resa);
            return View(resa);

        }
        */
    }
}
