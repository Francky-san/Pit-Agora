using System.Collections.Generic;
using System.IO;

namespace PitAgora.Models
{
    public class Professeur

    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public double CreditProf { get; set; }
     
        public string Motivation { get; set; }
    }
}
