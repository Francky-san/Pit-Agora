using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitAgora.Models;
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
        public IActionResult ChercherCours(string matiere, string niveau)
        {
            using (BddContext ctx = new BddContext())
            {
                var creneauxDispo = ctx.Creneaux.FromSqlRaw("select c.id, debut, c.reservationId, profId from creneaux as c " +
                    "inner join professeurs as p on p.id=c.profId " +
                    "where p.matiere1 = 'Techno' or p.matiere2 = 'Techno'").ToList();
                ViewData["creneaux"]=creneauxDispo;
                return View("ChoisirCours");
            }
        }


        [HttpGet]
        public IActionResult CreerReservation()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreerReservation(int eleve1Id, int professeurId, string matiere, string niveau, DateTime horaire, 
            List<Creneau> creneaux, bool binome, bool presentiel, int eleve2Id=0)
        {
            BddContext ctx = new BddContext();
            Reservation resa= new Reservation() { Eleve1Id=eleve1Id, Eleve2Id=eleve2Id, ProfesseurId=professeurId, 
                Matiere=matiere, Niveau=niveau, Horaire=horaire, Binome=binome, Presentiel=presentiel};
            ctx.Add(resa);
            return View(resa);
            
        }
    }
}
