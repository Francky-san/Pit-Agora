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

        public IActionResult AccueilProf(int id)
        {
            DalProf dalProf = new DalProf();
            Professeur professeur = dalProf.ObtientTousLesProfesseurs().FirstOrDefault(p => p.Id == id);
                       
            
            ProfViewModel pvm = new ProfViewModel() { Professeur=professeur };
            DalCreneaux dalCreneau = new DalCreneaux();
            pvm.CreneauxDisponibles = dalCreneau.GetCreneauxDisponibles(id);
            


            return View(pvm);
        }
        public IActionResult AfficherPlanning(int id)
        {
            DalProf dalProf = new DalProf();
            List<Creneau> mesCreneaux = dalProf.ListCreneaux(id);
            return View(mesCreneaux);
        }



    }
}
