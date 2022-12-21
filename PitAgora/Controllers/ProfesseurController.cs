using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;

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
            DalMatiereProf dalm = new DalMatiereProf();
            List<Matiere> matieres = new List<Matiere>();
            foreach (var prof in nosProfs)
            {
                matieres = dalm.GetMatiereProf(prof.Id);
            }
            DalNiveauxProf daln = new DalNiveauxProf();
            List<Niveau> niveaux = new List<Niveau>();
            foreach (var prof in nosProfs)
            {
                niveaux = daln.GetNiveauxProf(prof.Id);
            }
            ListProfViewModel lpvm = new ListProfViewModel() { matieres = matieres, niveaux = niveaux, profs = nosProfs };
            return View(lpvm);
        }



        // Méthode envoyant vers la vue Gérer mon planning
        [HttpGet]
        public IActionResult GererPlanning(int id, string jour)
        {
            DalProf dalProf = new DalProf();
            Professeur professeur = dalProf.ObtenirUnProf(id);

            DateTime dateTime= DateTime.Parse(jour);
            GererPlanningViewModel gpvm = new GererPlanningViewModel() { Professeur = professeur };
            DateTime lundi = Creneau.LundiPrecedent(dateTime);
            for (int i = 0; i < 7; i++)
            {
                gpvm.PlanningSemaine.Add(dalProf.CreerPlanningProf(id, lundi.AddDays(i)));
            }

            return View(gpvm);
        }

        // Méthode gérant les demandes de modification de planning
        [HttpPost]
        public IActionResult GererPlanning(string aAjouter, string aRetirer, int id)
        {
            DalCreneaux dal = new DalCreneaux();
            int aRetirerId;
            DateTime debut = DateTime.Now;
            if (aRetirer != null)
            {
                foreach (string s in aRetirer.Split(","))
                {
                    if (int.TryParse(s, out aRetirerId))
                    {
                        dal.SupprimerCreneau(aRetirerId);
                    }
                }
            }
            if (aAjouter != null)
            {
                foreach (string s in aAjouter.Split(","))
                {
                    if (s != "")
                    {
                        debut = DateTime.Parse(s);
                        dal.CreerCreneau(debut, id);
                    }
                }
            }
            return Redirect("/Professeur/GererPlanning?id=" + id + "&jour=" + debut.ToString());
        }

        [HttpGet]
        // Méthode envoyant vers la vue pour créer une évaluation
        public IActionResult CreerEvaluation(int professeurId, int reservationId)
        {
            ViewData["professeurId"] = professeurId;
            DalReservation dal = new DalReservation();
            return View(dal.GetReservation(reservationId));
        }

        [HttpPost]
        // Méthode gérant la nouvelle évaluation
        public IActionResult CreerEvaluation(int professeurId, string contenu, int reservationId)
        {
            DalReservation dal = new DalReservation();
            Evaluation evaluation = new Evaluation() { Contenu = contenu};
            int evaluationId = dal.CreerEvaluation(evaluation);
            dal.AffecterEvaluation(evaluationId, reservationId);

            return Redirect("/Professeur/AccueilProf/"+professeurId);
        }
    }
}
