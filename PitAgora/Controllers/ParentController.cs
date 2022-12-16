using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PitAgora.Controllers
{
    public class ParentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccueilParent(int Id)
        {
            DalParent dal = new DalParent();
            Parent parent = dal.ObtientTousLesParents().Where(p => p.Id == Id).FirstOrDefault();
            return View(GetPVM(parent));
        }

        //Méthode à part pour constituer ParentViewModel
        public ParentViewModel GetPVM(Parent parent)
        {
            DalEleve dal = new DalEleve();
            Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == parent.Id).FirstOrDefault();
            List<Reservation> resaEleve1 = dal.ObtenirReservations(eleve1.Id);
            DalReservation dalr = new DalReservation();
            List<Creneau> creneauxResa = new List<Creneau>();
            foreach (Reservation resa in resaEleve1)
            {
                creneauxResa = dalr.GetCreneaux(resa.Id);
            }

            ParentViewModel pvm = new ParentViewModel { Eleve = eleve1, Parent = parent, Reservations = resaEleve1, Creneaux = creneauxResa };
            return pvm;
        }

        [HttpGet]
        public IActionResult CrediterEleve()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrediterEleve(int parentId, int montant,int eleveId)
        {
            DalParent dal = new DalParent();
            dal.CrediterEleve(parentId, montant, eleveId);
            return View();
        }
    }
}
