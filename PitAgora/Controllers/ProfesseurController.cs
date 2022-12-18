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
            Professeur professeur = dalProf.ObtenirUnProf(id);
            ProfViewModel pvm = new ProfViewModel() { Professeur = professeur, };
            DalCreneaux dalCreneau = new DalCreneaux();
            pvm.CreneauxDisponibles = dalCreneau.GetCreneauxDisponibles(id);
            pvm.CreneauxReserves = dalCreneau.GetCreneauxReserves(id);
            DalReservation dalReservation = new DalReservation();
            pvm.CoursFuturs = dalReservation.GetCoursFuturs(id);
            pvm.CoursPasses = dalReservation.GetCoursPasses(id);


            return View(pvm);
        }

    }
}
