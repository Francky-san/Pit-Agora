using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;

namespace PitAgora.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult AccueilGeneral()
        {
          

            return View();
        }
    }
}
