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
        public IActionResult ChercherCours(string matiere, string niveau)
        {
            using (BddContext ctx = new BddContext())
            {
                var query = from prof in ctx.Professeurs
                            join c in ctx.Creneaux on prof.Id equals c.ProfId
                            where prof.Matiere1.Equals("Maths") || prof.Matiere2.Equals("Maths")
                            select c.Debut;

                //query = from prof in ctx.Professeurs
                //            join c in ctx.Creneaux on prof.Id equals c.ProfId
                //            join album in ctx.Album on booking.IdAlbum equals album.Id
                //            where contact.Mail.Contains("gmail")
                //            select new { contact.FirstName, contact.Mail, album.Title };
                var creneauxDispo = query.ToList();
                foreach (var item in creneauxDispo)
                {
                    Console.WriteLine(item.ToString());
                }
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
