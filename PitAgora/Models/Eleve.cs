namespace PitAgora.Models
{
    public class Eleve
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

       public int CreditPythos { get; set; }
       public int CreditCours { get; set; }

       public int ReservationId { get; set; }
        

    }
}