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
<<<<<<< HEAD

<<<<<<< HEAD
        public IActionResult Connexion()
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

        public IActionResult Profs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

=======
=======
        public IActionResult AfficherInfosEleve(Eleve eleve)
        {
            return View();
        }
>>>>>>> da68669 (Commit avant intégration layout MK)
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
                return View("AfficherInfosPerso", eleve) ;
            }
            else if (prof != null)
            {
                return View("InfosProf", prof);
            }
            else if (eleve1 != null)
            {
                return View("InfosParent", eleve1);
            }
            return View();
        }
>>>>>>> 3f8da31 (Ajout méthode AfficherInfos HomeController)
    }
}
