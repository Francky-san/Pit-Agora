using System;
using System.Collections.Generic;

namespace PitAgora.Models
{
    public class Creneau

    {
        public static readonly int NB_CRENEAUX_PAR_JOUR = 20;

        public int Id { get; set; }

        public DateTime Debut { get; set; }

        //FK vers professeur, relation plsrs creneaux appartiennent à un prof
        public int ProfesseurId { get; set; }
        public Professeur Professeur { get; set; }

        //FK vers reservation, relation plsrs à un. Un créneaux peut appartenir à une seule résa
        public int? ReservationId { get; set; }
        public Reservation Reservation { get; set; }




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

        // Donne l'intitule d'un jour sous forme 'Mercredi 1 janvier'
        public static string JourEnFrancais(DateTime d)
        {
            return Jour(d.DayOfWeek.ToString()) + " " + d.Day + " " + Mois(d.Month);
        }

        // Traduit le nom du jour en français
        public static string Jour(String day)
        {
            switch (day)
            {
                case "Monday":
                    return "Lundi";
                case "Tuesday":
                    return "Mardi";
                case "Wednesday":
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
        // Traduit le nom du jour en français
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

        public static DateTime LundiPrecedent(DateTime jour)
        {
            while(jour.DayOfWeek!=DayOfWeek.Monday)
            {
                jour = jour.AddDays(-1);
            }
            return jour;
        }
    }
}
