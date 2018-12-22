using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class User : IdentityUser<Guid>
    {
        [PersonalData]
        public string Position { get; set; }
        [PersonalData]
        public string Organisation { get; set; }
    }
    public class UserRole : IdentityRole<Guid>
    {
        //public string Description { get; set; }
    }
}
