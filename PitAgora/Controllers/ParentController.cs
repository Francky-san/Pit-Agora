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
        //Méthode renvoyant la vue accueil du parent avec le ParentViewModel comme model(parent, eleve)
        public IActionResult AccueilParent(int Id)
        {
            DalParent dal = new DalParent();
            Parent parent = dal.ObtientTousLesParents().Where(p => p.Id == Id).FirstOrDefault();
            return View(GetPVM(parent));
        }

        //Méthode à part pour constituer ParentViewModel à passer
        public ParentViewModel GetPVM(Parent parent)
        {
            DalEleve dal = new DalEleve();
            Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == parent.Id).FirstOrDefault();
            List<AReserve> resaEleve1 = dal.ObtenirReservations(eleve1.Id);
            DalReservation dalr = new DalReservation();
            List<Creneau> creneauxResa = new List<Creneau>();
            foreach (AReserve resa in resaEleve1)
            {
                creneauxResa = dalr.GetCreneaux(resa.ReservationId);
            }

            ParentViewModel pvm = new ParentViewModel { Eleve = eleve1, Parent = parent, Reservations = resaEleve1, Creneaux = creneauxResa };
            return pvm;
        }

        //Méthode get créditer porte monnaie élève
        [HttpGet]
        public IActionResult CrediterEleve(int Id)
        {
            return View(new CrediterViewModel { EleveId = Id, Montant = 0 }) ;
        }
        //Méthode post créditer porte monnaire élève
        [HttpPost]
        public IActionResult CrediterEleve(int montant,int EleveId)
        {
            DalParent dal = new DalParent();
            dal.CrediterEleve( montant, EleveId);
            return View();
        }
    }
}
