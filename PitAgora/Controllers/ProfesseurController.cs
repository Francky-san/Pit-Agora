using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Controllers
{
    public class ProfesseurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Postuler plus ou moins égal création d'un prof
        [HttpGet]
        public IActionResult Postuler()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Postuler(CandidatViewModel cvm)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        DalProf dal = new DalProf();
        //        int newProf = dal.CreerProfesseur(cvm.)
        //    }

        //}
        public IActionResult AccueilProf(int id)
        {
            DalProf dalProf = new DalProf();
            Professeur professeur = dalProf.ObtientTousLesProfesseurs().FirstOrDefault(p => p.Id == id);
            return View(professeur);
        }
        public IActionResult AfficherPlanning(int id)
        {
            DalProf dalProf = new DalProf();
            List<Creneau> mesCreneaux = dalProf.ListCreneaux(id);
            return View(mesCreneaux);

            DalReservation dalReservation = new DalReservation();
            // List<Reservation> mesReservations = dalReservation. ;


        }



    }
}