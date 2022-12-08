using System;
namespace PitAgora.Models
{
    public class Creneau

    {
        public int Id { get; set; }

        public DateTime Debut { get; set; }

        public int ProfId { get; set; }

        public int? ReservationId { get; set; }

        public virtual Reservation reservation { get; set; }


    }
}
