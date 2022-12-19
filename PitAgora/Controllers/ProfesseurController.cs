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

        // Méthode renvoyant la vue Accueil prof avec le professeur connecté comme modèle
        public IActionResult AccueilProf(int id)
        {
            DalProf dalProf = new DalProf();
            Professeur professeur = dalProf.ObtenirUnProf(id);

            ProfViewModel pvm = new ProfViewModel() { Professeur = professeur, };
            pvm.CoursFuturs = dalProf.GetCoursFuturs(id);
            pvm.CoursPasses = dalProf.GetCoursPasses(id);
            return View(pvm);
        }

        //Postuler plus ou moins égal création d'un prof
        [HttpGet]
        public IActionResult Postuler()
        {
            return View();
        }
        
        //Inscription professeur = création de l'objet professeur et intégration à la bdd
        [HttpPost]
        public IActionResult Postuler(CandidatViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                DalProf dal = new DalProf();
                int newProf = dal.CreerProfesseur(cvm.Professeur.Utilisateur.Personne.Nom, cvm.Professeur.Utilisateur.Personne.Prenom, cvm.Professeur.Utilisateur.Mail,
                    cvm.Professeur.Utilisateur.MotDePasse, cvm.Professeur.Utilisateur.Adresse);
            }
            return Redirect("/Home/Index");

        }

        //Contenu en dur, affichage de tous les profs
        public IActionResult ListeProfs()
        {
            DalProf dal = new DalProf();
            List<Professeur> nosProfs = dal.ObtientTousLesProfesseurs().ToList();
            return View(nosProfs);
        }



        // Méthode renvoyant la vue Gérer mon planning avec le professeur connecté comme modèle
        public IActionResult GérerPlanning(int id)
        {
            DalProf dalProf = new DalProf();
            Professeur professeur = dalProf.ObtenirUnProf(id);

            ProfViewModel pvm = new ProfViewModel() { Professeur = professeur, };

   
            return View();


        }

    }
 
}
