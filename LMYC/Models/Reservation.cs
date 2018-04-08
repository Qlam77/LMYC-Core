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

        [ForeignKey("User")]
        [Display(Name="Created By")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public ApplicationUser User { get; set; }

        [ForeignKey("Boat")]
        [Display(Name = "Reserved Boat")]
        public int ReservedBoat { get; set; }

        [ScaffoldColumn(false)]
        public Boat Boat { get; set; }

    }
}
