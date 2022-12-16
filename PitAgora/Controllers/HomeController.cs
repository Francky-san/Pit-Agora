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
                Eleve eleve1 = dal.ObtientTousLesELeves().Where(e => e.ParentId == parent.Id).FirstOrDefault();
                ParentViewModel pvm = new ParentViewModel { Eleve = eleve1, Parent = parent };
                return View("AccueilParent", pvm);
            }
            return View("ERROR");

        }
    }
}
