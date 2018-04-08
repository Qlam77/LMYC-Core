using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMYC.Models
{
    public class UserAndRolesHelper
    {
        public List<ApplicationUser> FirstTable { get; set; }
        public List<KeyValuePair<String, String>> SecondTable { get; set; }
        public List<IdentityRole> ThirdTable { get; set; }
    }
}
