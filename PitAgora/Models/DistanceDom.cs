using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public DistanceDom(int eleveId, int professeurId) {
            EleveId = eleveId;
            ProfesseurId = professeurId;

            using (BddContext ctx = new BddContext())
            {   
                Random random = new Random();   // pour Tests
                float profLong=random.Next(80), profLat= random.Next(80), eleveLong= random.Next(80), eleveLat= random.Next(80);  // initialistions : pour tests
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
                Distance = CalculerDistance(profLong, profLat, eleveLong, eleveLat);
            }
        }

        // ********************** Méthodes *********************
        public float CalculerDistance(float lo1, float la1, float lo2, float la2)
        {
            //mettre la formule de Joseph
            return Math.Abs(lo1-lo1) + Math.Abs(la1 -la2);  // pour Tests
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
