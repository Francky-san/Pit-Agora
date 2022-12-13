using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

namespace PitAgora.Controllers
{
    public class HomeController : Controller
    {

        static string requete;

        public IActionResult AccueilGeneral()
        {
            string longi = "";
            string lati = "";
            GetProductAsync("https://api-adresse.data.gouv.fr/search/?q=1+square+Jacques+Chirac&postcode=87000&city=Limoges");
            requete = requete.Substring(requete.IndexOf("coordinates") + 14);
            longi = requete.Substring(0, requete.IndexOf(","));
            lati =requete.Substring(requete.IndexOf(",") + 1, requete.IndexOf("]") - requete.IndexOf(",") - 1);
            return View();
        }

        static async void GetProductAsync(string path)
        {
            Product product = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);

            string data = "";

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
                
            }
            requete = data;
                   
        }

    }


}
