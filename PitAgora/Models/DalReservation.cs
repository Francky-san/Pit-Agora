using System;

namespace PitAgora.Models
{
    public class DalReservation : IDisposable
    {
        private BddContext _bddContext;
        public DalCreneaux()
        {
            _bddContext = new BddContext();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }


    }
}
