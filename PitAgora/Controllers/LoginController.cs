using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PitAgora.Models;
using PitAgora.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace PitAgora.Controllers
{
    public class LoginController : Controller
    {
        private DalGen dal;
        public LoginController()
        {
            dal = new DalGen();
        }
        public IActionResult Connexion()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated , Name= HttpContext.User.Identity.Name };
            if (viewModel.Authentifie)
            {
                viewModel.Utilisateur = dal.ObtenirUtilisateur(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Connexion(UtilisateurViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Utilisateur utilisateur = dal.Authentifier(viewModel.Utilisateur.Mail, viewModel.Utilisateur.MotDePasse);
                if (utilisateur != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, utilisateur.Id.ToString())
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/Home/AfficherAccueil/" + utilisateur.Id.ToString());
                }
                ModelState.AddModelError("Utilisateur.Mail", "Mail et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }


        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
