namespace PitAgora.Models
{
    public class Eleve
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; }

       public int CreditPythos { get; set; }
       public int CreditCours { get; set; }
        

    }
}