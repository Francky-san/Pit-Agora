using Microsoft.AspNetCore.Mvc;

namespace PitAgora.Controllers
{
    public class EleveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
