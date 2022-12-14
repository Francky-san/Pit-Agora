using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Collections.Generic;
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

>>>>>>> 40cc4a8292f80e17da7a77b8071c5bed7dffa03a
        public IActionResult AfficherInfosPerso(int Id)
        {
            DalEleve dal = new DalEleve();
            Eleve eleve = dal.ObtientTousLesELeves().Where(e => e.UtilisateurId == Id).FirstOrDefault();
            dal.ObtenirReservations(eleve.Id);
            DalProf dalProf = new DalProf();
            Professeur prof = dalProf.ObtientTousLesProfesseurs().Where(e => e.UtilisateurId == Id).FirstOrDefault();
            DalParent dalParent = new DalParent();
            Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == Id).FirstOrDefault();
            Parent parent = dalParent.ObtientTousLesParents().Where(p => p.UtilisateurId == Id).FirstOrDefault();
            List<Reservation> resaEleve1 = dal.ObtenirReservations(eleve1.Id);
            ParentViewModel pvm = new ParentViewModel { Eleve=eleve1, Parent=parent, Reservations=resaEleve1};
            if (eleve != null)
            {
<<<<<<< HEAD
                return View("AccueilEleve", eleve) ;
=======
                return View("AcceuilEleve", eleve) ;
>>>>>>> 40cc4a8292f80e17da7a77b8071c5bed7dffa03a
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
