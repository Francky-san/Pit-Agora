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
            return View();
        }

        [HttpPost]
        public IActionResult ChercherCours(string matiere, string niveau, DateTime horaire)
        {
            string gpeNiveau = Niveau.dictNiveaux[niveau];
            using (BddContext ctx = new BddContext())
            {
                var query = from p in ctx.Personnes
                            join u in ctx.Utilisateurs on p.Id equals u.PersonneId
                            join prof in ctx.Professeurs on u.Id equals prof.UtilisateurId
                            join c in ctx.Creneaux on prof.Id equals c.ProfId
                            where prof.Matiere1.Equals("Maths") || prof.Matiere2.Equals("Maths")
                            select new { p.Nom, c.Debut, c.Id };
                List<CreneauResaViewModel> creneauxDispo = new List<CreneauResaViewModel>();
                foreach (var item in query.ToList())
                {
                    creneauxDispo.Add(new CreneauResaViewModel() { NomProf = item.Nom, Debut = item.Debut, CreneauId = item.Id });
                }
                // test de la gestion du planning dans la page web
                List<PlanningViewModel> laListe = new List<PlanningViewModel>();
                laListe.Add(new PlanningViewModel("Tata", new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Tete", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Titi", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Toto", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                laListe.Add(new PlanningViewModel("Tutu", new bool[] { true, true, false, false, true, true, true, false, false, true, true, true, false, false, true, true, true, false, false, true }));
                return View("ChoisirCours", laListe);
            }
        }


        [HttpGet]
        public IActionResult CreerReservation()
        {
            return View();

        }
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

    }
}
