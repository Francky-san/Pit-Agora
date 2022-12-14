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

<<<<<<< HEAD
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
=======
>>>>>>> 3f8da31 (Ajout méthode AfficherInfos HomeController)
=======
=======
>>>>>>> da68669f75ba9138d8fe2df4863f76cb4badb97f
        public IActionResult AfficherInfosEleve(Eleve eleve)
        {
            return View();
        }
<<<<<<< HEAD
>>>>>>> da68669 (Commit avant intégration layout MK)
=======
>>>>>>> da68669f75ba9138d8fe2df4863f76cb4badb97f
        public IActionResult AfficherInfosPerso(int Id)
        {
            DalEleve dal = new DalEleve();
            Eleve eleve = dal.ObtientTousLesELeves().Where(e => e.UtilisateurId == Id).FirstOrDefault();
            DalProf dalProf = new DalProf();
            Professeur prof = dalProf.ObtientTousLesProfesseurs().Where(e => e.UtilisateurId == Id).FirstOrDefault();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> da68669f75ba9138d8fe2df4863f76cb4badb97f
            DalParent dalParent = new DalParent();
            Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == Id).FirstOrDefault();
            if (eleve != null)
            {
<<<<<<< HEAD
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
=======
            DalParent dalParent= new DalParent();
            Eleve eleve1 = dal.ObtientTousLesELeves().Where(e=>e.ParentId == Id).FirstOrDefault();
=======
            DalParent dalParent = new DalParent();
            Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == Id).FirstOrDefault();
>>>>>>> da68669 (Commit avant intégration layout MK)
            if (eleve != null)
            {
=======
>>>>>>> da68669f75ba9138d8fe2df4863f76cb4badb97f
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
<<<<<<< HEAD
>>>>>>> 3f8da31 (Ajout méthode AfficherInfos HomeController)
=======
>>>>>>> da68669f75ba9138d8fe2df4863f76cb4badb97f
        }
    }
}
