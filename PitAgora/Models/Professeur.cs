using System.Collections.Generic;

namespace PitAgora.Models
{
    public class Professeur

    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public int CreditProf { get; set; }

    }
}
