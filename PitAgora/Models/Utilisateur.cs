using System.ComponentModel.DataAnnotations;
namespace PitAgora.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public int PersonneId { get; set; }
        public Personne Personne { get; set; }
        public string Mail { get; set; }
       [Display(Name="Mot de passe")]

        public string MotDePasse { get; set; }
        public string Adresse { get; set; }
        //longitude et latitude utiles?
        public float Longitude { get; set; }
        public float Latitude { get; set; }

    }
}
