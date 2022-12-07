using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitAgora.Models;
using System;
using System.Collections.Generic;

namespace PitAgora.Controllers
{
    public class EleveController : Controller
    {
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
                var creneauxDispo = ctx.Creneaux.FromSqlRaw("select * from creneaux ");
            }
            
            return View();
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
                Matiere=matiere, Niveau=niveau, Horaire=horaire, Creneaux=creneaux, Binome=binome, Presentiel=presentiel};
            ctx.Add(resa);
            return View(resa);
            
        }
    }
}
