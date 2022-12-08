using System.Collections.Generic;

namespace PitAgora.Models
{
    public class Professeur

    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public string Matiere1 { get; set; }
        public string Matiere2 { get; set; }
        public int CreditProf { get; set; }
        public int ReservationId { get; set; }
    }
}
