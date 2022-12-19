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

        //M�thode renvoyant accueil professeur avec le professeur connect� comme model
        public IActionResult AccueilProf(int id)
        {
            DalProf dalProf = new DalProf();
            Professeur professeur = dalProf.ObtenirUnProf(id);
            ProfViewModel pvm = new ProfViewModel() { Professeur = professeur, };
            DalCreneaux dalCreneau = new DalCreneaux();
            pvm.CreneauxDisponibles = dalCreneau.GetCreneauxDisponibles(id);
            pvm.CreneauxReserves = dalCreneau.GetCreneauxReserves(id);
            /*DalReservation dalReservation = new DalReservation();
            pvm.CoursFuturs = dalReservation.GetCoursFuturs(id);
            pvm.CoursPasses = dalReservation.GetCoursPasses(id);*/


            return View(pvm);
        }

        //M�thode renvoyant la vue planning, r�cup�ration de tous les cr�neaux li�s au professeur
        public IActionResult AfficherPlanning(int id)
        {
            DalProf dalProf = new DalProf();
            //List<Creneau> mesCreneaux = dalProf.ListCreneaux(id);
            return View();

            DalReservation dalReservation = new DalReservation();
            // List<Reservation> mesReservations = dalReservation. ;


        }
        //Postuler plus ou moins �gal cr�ation d'un prof
        [HttpGet]
        public IActionResult Postuler()
        {
            return View();
        }
        //Inscription professeur = création de l'objet professeur et int�gration � la bdd
        [HttpPost]
        public IActionResult Postuler(CandidatViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                DalProf dal = new DalProf();
                int newProf = dal.CreerProfesseur(cvm.Professeur.Utilisateur.Personne.Nom, cvm.Professeur.Utilisateur.Personne.Prenom, cvm.Professeur.Utilisateur.Mail,
                    cvm.Professeur.Utilisateur.MotDePasse, cvm.Professeur.Utilisateur.Adresse) ;
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




    }
}