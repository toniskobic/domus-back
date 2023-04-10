using domus.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domus.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Locked { get; set; }
        public int DormitoryId { get; set; }

        public virtual Dormitory Dormitory { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }


    }
}
