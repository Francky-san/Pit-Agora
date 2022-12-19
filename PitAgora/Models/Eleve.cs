namespace PitAgora.Models
{
    public class Eleve
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        //Suppression FK reservation, table AReserve = table intermediaire eleve/reservation


        public int CreditPythos { get; set; }
        public double CreditCours { get; set; }


    }
}