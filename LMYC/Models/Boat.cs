using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMYC.Models
{
    public class Boat
    {
        [Key]
        public int BoatId { get; set; }

        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string BoatName { get; set; }

        public string Picture { get; set; }

        [Display(Name = "Length")]
        [Range(0, 1000)]
        public double LengthInFeet { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Make { get; set; }

        [Display(Name = "Year")]
        [Range(1900, 2020)]
        public int Year { get; set; }

        public string RecordCreationDate { get; set; }

        [ForeignKey("User")]
        [ScaffoldColumn(false)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public ApplicationUser User { get; set; }
    }
}
