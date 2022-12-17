using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
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
            return View(professeur);
        }
        public IActionResult AfficherPlanning(int id)
        {
            DalProf dalProf = new DalProf();
            List<Creneau> mesCreneaux = dalProf.ListCreneaux(id);
            return View(mesCreneaux);



                     

        }



    }
}
