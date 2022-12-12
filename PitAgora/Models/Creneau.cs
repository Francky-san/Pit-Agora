using System;
using System.Collections.Generic;

namespace PitAgora.Models
{
    public class Creneau

    {
        public static readonly int NB_CRENEAUX_PAR_JOUR = 20;

        public int Id { get; set; }

        public DateTime Debut { get; set; }

        public int ProfesseurId { get; set; }

        public int? ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }


        // ************ Constructeurs **************

        public Creneau()
        {
        }

        // crée un créneau à partir des infos de la BDD
        public Creneau(int id)  
        {
            BddContext ctx = new BddContext;
            var query = from c in ctx.Creneaux
                        where c.Id == id
                        select c;
            this.Id = id;
            this.Debut = query;
            this.
        }



        // ***************** Méthodes *********************

        // Renvoie le rang du créneau dans un planing (9:00-9:30 -> 0)
        public int Rang()
        {
            return 2 * Debut.Hour + (Debut.Minute / 30) - 18;
        }

        // Convertit une liste de créneaux (même prof / même jour) en un tableau de booléens pour avoir les disponibilités sur la journée
        public bool[] PlanningBool(List<Creneau> creneauList)
        {
            bool[] res = new bool[NB_CRENEAUX_PAR_JOUR];
            foreach (Creneau c in creneauList)
            {
                res[c.Rang()] = true;
            }
            return res;
        }

        public static string Jour(String day)
        {
            switch (day)
            {
                case "Monday":
                    return "Lundi";
                case "Tuesday":
                    return "Mardi";
                case "Wenensday":
                    return "Mercredi";
                case "Thursday":
                    return "Jeudi";
                case "Friday":
                    return "Vendredi";
                case "Saturday":
                    return "Samedi";
                case "Sunday":
                    return "Dimanche";
                default:
                    return "Erreur";
            }
        }
        public static string Mois(int month)
        {
            switch (month)
            {
                case 1:
                    return "janvier";
                case 2:
                    return "février";
                case 3:
                    return "mars";
                case 4:
                    return "avril";
                case 5:
                    return "mai";
                case 6:
                    return "juin";
                case 7:
                    return "juillet";
                case 8:
                    return "août";
                case 9:
                    return "septembre";
                case 10:
                    return "octobre";
                case 11:
                    return "novembre";
                case 12:
                    return "décembre";
                default:
                    return "Erreur";
            }
        }
    }
}
