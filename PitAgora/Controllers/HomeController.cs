using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Linq;

namespace PitAgora.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Inscription()
        {
            return View();
        }

        public IActionResult Postuler()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        //Méthodes Franck pour renvoyer infos
        public IActionResult AfficherInfosPerso(int Id)
        {
            DalEleve dal = new DalEleve();
            Eleve eleve = dal.ObtientTousLesELeves().Where(e => e.UtilisateurId == Id).FirstOrDefault();
            DalProf dalProf = new DalProf();
            Professeur prof = dalProf.ObtientTousLesProfesseurs().Where(e => e.UtilisateurId == Id).FirstOrDefault();
            DalParent dalParent = new DalParent();
            Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == Id).FirstOrDefault();
            if (eleve != null)
            {
                return View("AccueilEleve", eleve) ;
            }
            else if (prof != null)
            {
                return View("AccueilProf", prof);
            }
            else if (eleve1 != null)
            {
                return View("AccueilParent", eleve1);
            }
            return View("ERROR");
        }
    }
}
