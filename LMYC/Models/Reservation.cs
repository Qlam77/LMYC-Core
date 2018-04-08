using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMYC.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name="Created By")]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public ApplicationUser User { get; set; }

        [ForeignKey("Boat")]
        [Display(Name = "Reserved Boat")]
        public int ReservedBoat { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<Boat> Boats { get; set; }

    }
}
