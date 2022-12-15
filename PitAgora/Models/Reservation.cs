using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PitAgora.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        //Suppression FK Eleve, la table intermediaire pointe vers Eleve et pointe vers Reservation, relation plsrs à plsrs

        //Suppression FK prof, prof pointe créneau qui pointe réservation, relation un à plsrs
        public DateTime Horaire { get; set; }
        public float Prix { get; set; }
        public bool EstEnBinome { get; set; }
        public bool EstEnPresentiel { get; set; }
        public bool EstValide { get; set; }
    }
    
}
