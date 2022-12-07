using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;

namespace PitAgora.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Personne personne = new Personne { Nom = "TANGUY", Prenom = "Hina" };

            HomeViewModel hvm = new HomeViewModel
            {
                Message = "Bonjour tout le monde",
                Date = DateTime.Now,
                Personne = personne
            };

            return View(hvm);
        }
    }
}
