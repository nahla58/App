using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Reservation
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date de réservation")]

        public DateTime DateReservation { get; set; }
        [Range(1,4)]
        public int NbPersonnes { get; set; }
        public virtual Pack Pack { get; set; }
        public virtual Client Client { get; set; }
        public int IdClient { get; set; }
        public int IdPack { get; set; }
    }
}
