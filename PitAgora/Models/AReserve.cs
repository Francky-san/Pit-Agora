namespace PitAgora.Models
{
    public class AReserve
    {
        //Table intermediaire entre eleve et reservation
        public int Id { get; set; }
        //FK vers eleve
        public int EleveId { get; set; }
        public Eleve Eleve { get; set;}
        //FK vers reservation
        public int ReservationId { get; set; }  
        public Reservation Reservation { get; set; }    

    }
}
