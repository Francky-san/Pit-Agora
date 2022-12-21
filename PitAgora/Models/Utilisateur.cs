using System.ComponentModel.DataAnnotations;
namespace PitAgora.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public int PersonneId { get; set; }
        public Personne Personne { get; set; }
        [MaxLength(30)]
        public string Mail { get; set; }
        [MaxLength(50)]
        [Display(Name="Mot de passe")]

        public string MotDePasse { get; set; }
        [MaxLength(60)]
        public string Adresse { get; set; }
        //longitude et latitude utiles?
        public float Longitude { get; set; }
        public float Latitude { get; set; }

    }
}
