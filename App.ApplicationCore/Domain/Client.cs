using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Client
    {
        [Key]
        public int Identifiant { get; set; }

        [Required(ErrorMessage = "il faut saisir le login.")]
        public string Login { get; set; }
        [Required ]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
        public string Photo { get; set; }
        public int ConseillerFk { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual Conseiller Conseiller { get; set; }
    }
}
