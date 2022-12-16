using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
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
                int newEleve = dalE.CreerEleve(ivm.Eleve.Utilisateur.Personne.Nom, ivm.Eleve.Utilisateur.Personne.Prenom, ivm.Eleve.Utilisateur.Mail,
                    newParent, ivm.Eleve.Utilisateur.MotDePasse, ivm.Parent.Utilisateur.Adresse);
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
                return View("AccueilEleve", eleve) ;
            }
            else if (prof != null)
            {
                return View("AccueilProf", prof);
            }
            else if (parent != null)
            {
                Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == parent.Id).FirstOrDefault();
                ParentViewModel pvm = new ParentViewModel { Eleve = eleve1, Parent = parent };
                return View("AccueilParent", pvm);
            }
            return View("ERROR");

        }
    }
}
