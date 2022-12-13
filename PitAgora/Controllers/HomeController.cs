using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
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
            GetProductAsync("https://api-adresse.data.gouv.fr/search/?q=1+square+Jacques+Chirac&postcode=87000&city=Limoges");

            return View();
        }

        static async void GetProductAsync(string path)
        {
          
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(path);

            string longi = "";
            string lati = "";
            string requete = "";

            if (response.IsSuccessStatusCode)
            {
                requete = await response.Content.ReadAsStringAsync();

                requete = requete.Substring(requete.IndexOf("coordinates") + 14);
                longi = requete.Substring(0, requete.IndexOf(","));
                lati = requete.Substring(requete.IndexOf(",") + 1, requete.IndexOf("]") - requete.IndexOf(",") - 1);

                Console.WriteLine("Longitude : " + longi + "\n Latitude : " + lati);
            }




            //requete = data;

        }

    }


}
