using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PitAgora.Models
{
    public class Personne
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required(ErrorMessage = "Le Nom doit être renseigné.")]
        public string Nom { get; set; }
        [MaxLength(25)]
        [Required(ErrorMessage = "Le Prénom doit être renseigné.")]
        public string Prenom { get; set; }


    }
}
