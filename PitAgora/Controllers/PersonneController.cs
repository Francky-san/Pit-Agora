using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using System.Linq;

namespace PitAgora.Controllers
{
    public class PersonneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ModifierPersonne(int id)
        {
            if (id != 0)
            {
                using (DalGen dal = new DalGen())

                {
                    Personne personne = dal.ObtientToutesPersonnes().Where(r => r.Id == id).FirstOrDefault();
                    if (personne == null)
                    {
                        return View("Error");
                    }
                    return View(personne);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult ModifierPersonne(Personne personne)
        {
            if (!ModelState.IsValid)
                return View(personne);

            if (personne.Id != 0)
            {
             using (DalGen dal = new DalGen())
                {
                    dal.ModifierPersonne(personne);
                    return RedirectToAction("ModifierPersonne", new { @id = personne.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult CreerPersonne()
        {
            return View();
          
        }

        [HttpPost]
        public IActionResult CreerPersonne (Personne personne)
        {
            if (!ModelState.IsValid)
                return View(personne);

            if (personne.Id != 0)
            {
                using (DalGen dal = new DalGen())
                {
                    dal.CreerPersonne(personne);
                    return RedirectToAction("CreerPersonne", new { @id = personne.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }
    }
}
