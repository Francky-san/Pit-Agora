namespace PitAgora.Models
{
    public class Utilisateur
    { 
        public int Id { get; set; }
        public int PersonneId { get; set; }
        public Personne Personne { get; set; }
        public string Mail { get; set; }
        public string MotDePasse { get; set; }  
        public string Adresse { get; set; }
        
    }
}
