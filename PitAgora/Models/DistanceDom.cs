using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitAgora.Models;
using PitAgora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PitAgora.Models
{
    // Table de toutes les distances Eleve/Prof inférieures à DIST_MAX
    // A mettre à jour lors de toute création/modification d'adresse d'un élève ou d'un prof
    public class DistanceDom
    {
        public static readonly int DIST_MAX = 30;
        public int Id { get; set; }
        public float Distance { get; set; }
        public int EleveId { get; set; }
        public virtual Eleve Eleve { get; set; }
        public int ProfesseurId { get; set; }
        public virtual Professeur Professeur { get; set; }

        // Constructeur
        public DistanceDom(int eleveId, int professeurId)
        {
            EleveId = eleveId;
            ProfesseurId = professeurId;

            using (BddContext ctx = new BddContext())
            {
                Random random = new Random();   // pour Tests
                float eleveLat = random.Next(80), eleveLong = random.Next(80), profLat = random.Next(80), profLong = random.Next(80) ;  // initialistions : pour tests
                // Recherche des coordonnées du Professeur
                /*var query = from u in ctx.Utilisateurs   // !!! A décommenter quand les utilisateurs auront leurs coordonnées !!!
                            join prof in ctx.Professeurs on u.Id equals prof.UtilisateurId
                            where prof.Id.Equals(professeurId)
                            select new { u.Longitude, u.Latitude };
                if (query.Count() != 1 ) {
                    Console.WriteLine("Erreur d'association dans la table 'Distances domiciles'");
                } else {
                    foreach (var item in query.ToList())
                    {
                        profLong = item.Longitude;
                        profLat = item.Latitude;
                    }
                }
                // Recherche des coordonnées de l'Elève
                query = from p in ctx.Personnes
                            join u in ctx.Utilisateurs on p.Id equals u.PersonneId
                            join e in ctx.Eleves on u.Id equals e.UtilisateurId
                            where e.Id.Equals(eleveId)
                            select new { u.Longitude, u.Latitude };
                if (query.Count() != 1)
                {
                    Console.WriteLine("Erreur d'association dans la table 'Distances domiciles'");
                }
                else
                {
                    foreach (var item in query.ToList())
                    {
                        eleveLong = item.Longitude;
                        eleveLat = item.Latitude;
                    }
                }*/

                // Calcul et affectation de la distance
                Distance = CalculerDistance(eleveLat, eleveLong, profLat, profLong);


            }
        }

        // ********************** Méthodes *********************

        // Récupération latitude et longitude à partir d'une adresse postale
        //public float ObtenirLatitudeEtLongitude (string adresse, float Latitude, float Longitude)
        //{
        //    adresse = "1 + square + Jacques + Chirac & postcode = 87000 & city = Limoges";
        //    double = href



        //    static async Task<Product> GetProductAsync(string path)
        //    {

        //        var AdresseDataGouv = new HttpAdresseDataGouv;

        //            Product product = null;
        //        HttpResponseMessage response = await client.GetAsync(https://api-adresse.data.gouv.fr/search/);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            product = await response.Content.ReadAsAsync<Product>();
        //        }
        //        return product;
        //    }




        }



        // Calcul distance entre élève et prof avec latitude et longitude de chacun
        public float CalculerDistance (float eleveLat, float eleveLong, float profLat, float profLong)
        {
            // Calcul de l'angle en radian de l'arc de cercle entre élève et prof
            float angleEnRadian = (float)Math.Sin(Math.PI / 180 * eleveLat) *
                    (float)Math.Sin(Math.PI / 180 * profLat) +
                    (float)Math.Cos(Math.PI / 180 * eleveLat) *
                    (float)Math.Cos(Math.PI / 180 * profLat) *
                    (float)Math.Cos(Math.PI / 180 * (eleveLong - profLong));

            // Distance entre A et B = longueur de l'arc multiplié par le rayon de la terre exprimé en km (source IGN)
            float distance = ((float)Math.Acos(angleEnRadian)) * 6378.137f;

            // Résulat arrondi à un chiffre après la virgule
            distance = (float)Math.Round(distance, 1);

            Console.WriteLine ("La distance élève/prof est : " + distance + " km");


            return Math.Abs(eleveLat - profLat) + Math.Abs(eleveLong - profLong);  // pour Tests
        }

        // ************************ TESTS **********************
        public static void TestCalculerDistance()
        {
            BddContext ctx1 = new BddContext();
            foreach (Eleve e in ctx1.Eleves)
            {
                BddContext ctx2 = new BddContext();
                foreach (Professeur p in ctx2.Professeurs)
                {
                    DistanceDom dist = new DistanceDom(e.Id, p.Id);
                    if (dist.Distance <= DIST_MAX)
                    {
                        ctx2.DistanceDoms.Add(dist);
                    }
                }
                ctx2.SaveChanges();
            }
        }
    }
}
