using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
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

        public IActionResult Postuler()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inscription(InscriptionViewModel ivm)
        {
            if (ModelState.IsValid)
            {
                DalParent dalP = new DalParent();
                DalEleve dalE = new DalEleve();
                int newParent = dalP.CreerParent(ivm.Parent.Utilisateur.Personne.Nom, ivm.Parent.Utilisateur.Personne.Prenom, ivm.Parent.Utilisateur.Mail,
                    ivm.Parent.Utilisateur.MotDePasse, ivm.Parent.Utilisateur.Adresse);
                int newEleve = dalE.CreerEleve(newParent, ivm.Eleve.Utilisateur.Personne.Nom, ivm.Eleve.Utilisateur.Personne.Prenom, ivm.Eleve.Utilisateur.Mail,
                     ivm.Eleve.Utilisateur.MotDePasse, ivm.Parent.Utilisateur.Adresse);
            }
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
            Parent parent = dalParent.ObtientTousLesParents().Where(p => p.UtilisateurId == Id).FirstOrDefault();
     
            if (eleve != null)
            {
                return Redirect("/Eleve/AccueilEleve/"+ eleve.ToString()) ;
            }
            else if (prof != null)
            {
                return Redirect("/Professeur/AccueilProf/"+ prof.ToString());
            }
            else if (parent != null)
            {
                return View("AccueilParent", GetPVM(parent));
            }
            return View("ERROR");

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

            ParentViewModel pvm = new ParentViewModel { Eleve = eleve1, Parent = parent,Reservations=resaEleve1,Creneaux=creneauxResa };
            return pvm;
        }
    }
}
