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
                    cvm.Professeur.Utilisateur.MotDePasse, cvm.Professeur.Utilisateur.Adresse, cvm.MatiereProf.MatiereId) ;
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

        //Méthode renvoyant accueil professeur avec le professeur connecté comme model
        public IActionResult AccueilProf(int id)
        {
            DalProf dalProf = new DalProf();
            Professeur professeur = dalProf.ObtientTousLesProfesseurs().FirstOrDefault(p => p.Id == id);
            return View(professeur);
        }

        //Méthode renvoyant la vue planning, récupération de tous les créneaux liés au professeur
        public IActionResult AfficherPlanning(int id)
        {
            DalProf dalProf = new DalProf();
            List<Creneau> mesCreneaux = dalProf.ListCreneaux(id);
            return View(mesCreneaux);

            DalReservation dalReservation = new DalReservation();
            // List<Reservation> mesReservations = dalReservation. ;


        }



    }
}