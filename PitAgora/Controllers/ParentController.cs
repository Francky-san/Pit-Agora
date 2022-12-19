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
            List<Reservation> resaPassees = dal.ObtenirCoursPasses(eleve1.Id);
            List<Reservation> resaFutures = dal.ObtenirCoursFuturs(eleve1.Id);

            DalReservation dalr = new DalReservation();

            ParentViewModel pvm = new ParentViewModel { Eleve = eleve1, Parent = parent, CoursFuturs = resaFutures, CoursPasses = resaPassees };
            return pvm;
        }

        //Méthode get créditer porte monnaie élève
        [HttpGet]
        public IActionResult CrediterEleve(int ed, int id)
        {
            return View(new CrediterViewModel { EleveId = ed, Montant = 0, ParentId=id}) ;
        }
        //Méthode post créditer porte monnaire élève
        [HttpPost]
        public IActionResult CrediterEleve(int montant,int EleveId, int ParentId)
        {
            DalParent dal = new DalParent();
            dal.CrediterEleve( montant, EleveId, ParentId);
            return Redirect("AccueilParent/"+ParentId);
        }
    }
}
