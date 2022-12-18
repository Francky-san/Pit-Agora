using System;

namespace PitAgora.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        //Suppression FK Eleve, la table intermediaire pointe vers Eleve et pointe vers Reservation, relation plsrs à plsrs
        public string PrenomNomProf { get; set; }
        //Suppression FK prof, prof pointe créneau qui pointe réservation, relation un à plsrs
        public DateTime Horaire { get; set; }
        public string Jour { get; set; }   // pour afficher le jour en français
        public int DureeMinutes { get; set; }
        public MatiereEnum Matiere { get; set; } // faire une FK ?
        public NiveauEnum Niveau { get; set; }  // faire une FK ?
        public double Prix { get; set; }
        public bool EstEnBinome { get; set; }
        public bool EstEnPresentiel { get; set; }
        public bool EstValide { get; set; }
        //FT - Ajout FK vers évaluation, évaluation relative à la réservation.
        public int? EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
    }
    
}
