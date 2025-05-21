using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;

namespace App.ApplicationCore.Services
{
    public class ReservationService : Service<Reservation>, IReservationService
    {
        public ReservationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public int NombreReservation(Client client)
        {
            if (client?.Reservations == null)
                return 0;
            int anneeEnCours= DateTime.Now.Year;
            return client.Reservations.Count(r =>r.DateReservation.Year == anneeEnCours);
        }
    }
   
}
