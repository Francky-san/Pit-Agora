using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace PitAgora.Controllers
{
    public class HomeController : Controller
    {
        // Point d'entrée de l'application, envoie vers la vue d'accueil
        public IActionResult Index()
        {
            return View();
        }

        //Contenu en dur, présentation Pit'Agora
        public IActionResult Presentation()
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

            return View("PayerInscription");
        }

        public IActionResult MessageApresPaiement()
        {
            return View();
        }



        //Méthodes Franck pour renvoyer infos
        public IActionResult AfficherAccueil(int Id)
        {
            DalEleve dal = new DalEleve();
            Eleve eleve = dal.ObtientTousLesELeves().Where(e => e.UtilisateurId == Id).FirstOrDefault();
            DalProf dalProf = new DalProf();
            Professeur prof = dalProf.ObtientTousLesProfesseurs().Where(e => e.UtilisateurId == Id).FirstOrDefault();
            DalParent dalParent = new DalParent();
            Parent parent = dalParent.ObtientTousLesParents().Where(p => p.UtilisateurId == Id).FirstOrDefault();
     
            if (eleve != null)
            {
                return Redirect("/Eleve/AccueilEleve/"+ eleve.Id) ;
            }
            else if (prof != null)
            {
                return Redirect("/Professeur/AccueilProf/"+ prof.Id);

            }
            else if (parent != null)
            {
                return Redirect("/Parent/AccueilParent/"+parent.Id);
            }
            return View("ERROR");

        }

    }
}
