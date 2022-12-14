using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using System.Linq;

namespace PitAgora.Controllers
{
    public class ProfesseurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
