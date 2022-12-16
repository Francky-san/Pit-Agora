using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using System.Collections.Generic;

namespace PitAgora.Controllers
{
    public class ProfesseurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccueilProf(Professeur prof)
        {
            return View(prof);
        }
        public IActionResult AfficherPlanning(Professeur professeur)
        {
            DalProf dalProf = new DalProf();

            List<Creneau> mesCreneaux = dalProf.ListCreneaux(professeur.Id);
            return View(mesCreneaux);

        }


    }
}
