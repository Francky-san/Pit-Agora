using System.Collections.Generic;

namespace PitAgora.Models
{
    public class Professeur

    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public string Matiere1 { get; set; }
        public string Matiere2 { get; set; }
        public int CreditProf { get; set; }
        //suppression FK reservation creneau = table intermediaire prof/reservation
      
    }
}
